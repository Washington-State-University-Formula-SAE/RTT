import os
import can
from vehicleMQTT import *
import time
import serial

class CANInterface():
    def __init__(self):
        self.vehicleRPM = vehicleRPM()
        self.vehicleSpeed = vehicleSpeed()
        self.acceleratorPosition = acceleratorPosition()        
        self.brakeActive = brakeActive()
        self.vehicleGearActive = vehicleGearActive()

    def start_receive_can(self):
        # CAN
        os.system('sudo ip link set can0 type can bitrate 500000')
        os.system('sudo ifconfig can0 up')
        can0 = can.interface.Bus(channel = 'can0', bustype = 'socketcan_ctypes')

        # Receive messages
        while True:
            msg = can0.recv(30.0)
            if msg:
                msg = str(msg).split()
                print (msg)     
                self.__AddToSensor(msg)
            else:
                print('No message was received')

    def start_receive_serial(self):
        ser = serial.Serial(
                    port="COM3",
                    baudrate=9600,
                    write_timeout=2,
                    timeout=2
                )
        time.sleep(5)
        while 1:
            num_bytes_in_waiting = ser.in_waiting
            messages = ser.readline().decode('utf-8').split('\n')
            for message in messages:
                message = message.split()
                if len(message) > 0:
                    message[1] = message[1][0:-1]
                    if message[0] == 'ID:':
                        self.__AddToSensor(message)

                #print(message)

    def __AddToSensor(self, message):
            if message[1] == '201': # accelerator position, rpm, speed 41 230 215 211 91 250 201
                speedMessage = (((int(message[7], 16)*256)+int(message[8], 16)) / 100) - 100 # km/h
                join = ''.join(message[3:5])
                rpmMessage1 = int(message[3], 16) 
                rpmMessage2 = int(message[4], 16)
                rpmMessage= (int(join, 16)/4)
                acceleratorMessage = (int(message[9], 16))
                #print(speedMessage)
                #print(rpmMessage)
                #print(acceleratorMessage)
                #speedMessage = 45
                #rpmMessage = 3432
                #acceleratorMessage = 50 # max is 200
                self.vehicleSpeed.SendData(speedMessage)
                #self.vehicleRPM.SendData(rpmMessage)
                self.acceleratorPosition.SendData(acceleratorMessage)
            if message[1] == '208':
                print(message)
            elif message[1] == '205':
                brakeApplied = (int(message[9], 16))
                self.brakeActive.SendData(brakeApplied)
            elif message[1] == '230':
                if (message[3] =='8DD'):
                    self.vehicleGearActive.SendData(-1)
                elif (message[3] == '8A1'):
                    self.vehicleGearActive.SendData(-2)
                elif (message[3] == '8EE'):
                    self.vehicleGearActive.SendData(0)
                elif (message[3] == '817'):
                    self.vehicleGearActive.SendData(1)
                elif (message[3] == '827'):
                    self.vehicleGearActive.SendData(2)
                elif (message[3] == '837'):
                    self.vehicleGearActive.SendData(3)
                elif (message[3] == '847'):
                    self.vehicleGearActive.SendData(4)
                elif (message[3] == '857'):
                    self.vehicleGearActive.SendData(5)
                elif (message[3] == '867'):
                    self.vehicleGearActive.SendData(5)
                print(message)


