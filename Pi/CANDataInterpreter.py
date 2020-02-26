from MQTT.vehicleMQTT import *
import os
import can
import time
import serial

class CANInterface():

    def __init__(self):
        self.vehicleRPM = vehicleRPM()
        self.vehicleSpeed = vehicleSpeed()
        self.acceleratorPosition = acceleratorPosition()        
        self.brakeActive = brakeActive()
        self.vehicleGearActive = vehicleGearActive()

        self.canMessage = None
        self.canId = None

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
                self.canMessage = msg
                self.canId = msg[1]
                self.__add_to_sensor(self.canId)
            else:
                print('No message was received')

    def start_receive_serial(self, com_port, baud):
        ser = serial.Serial(
                    port=com_port,
                    baudrate=baud,
                    write_timeout=2,
                    timeout=2
                )

        time.sleep(5)

        while True:
            num_bytes_in_waiting = ser.in_waiting
            serial_messages = ser.readline().decode('utf-8').split('\n')

            for message in serial_messages:
                message = message.split()
                if len(message) > 0:
                    message[1] = message[1][0:-1]
                    if message[0] == 'ID:': # additional check to ensure that message is from CAN shield
                        self.__add_to_sensor(message[1])


    # send current speed from ford can-bus
    def speed_ford(self):
        # int(byte, 16) converts byte from hex to decimal
        speedMessage = (((int(self.canMessage[7], 16)*256)+int(self.canMessage[8], 16)) / 100) - 100 # combine two bytes into km/h
        
        joinHex = ''.join(self.canMessage[3:5]) # combine multiple bytes into one string
        rpmMessage = (int(joinHex, 16)/4)

        acceleratorMessage = (int(self.canMessage[9], 16)) # accelerator position, max value is 200

        self.vehicleSpeed.SendData(speedMessage) # send vehicle speed to server
        self.vehicleRPM.SendData(rpmMessage)    # send vehicle rpm to server
        self.acceleratorPosition.SendData(acceleratorMessage) # send accelerator position to server

    # if the brake pedal is being pressed, ford
    def brake_applied_ford(self):
        brakeApplied = int(self.canMessage[9], 16)
        self.brakeActive.SendData(brakeApplied)

    # get current active gear
    def gear_active_ford(self):
        if (self.canMessage[3] =='8DD'): # neutral
            self.vehicleGearActive.SendData(-1)
        elif (self.canMessage[3] == '8A1'): # reverse
            self.vehicleGearActive.SendData(-2)
        elif (self.canMessage[3] == '8EE'): # 1st gear
            self.vehicleGearActive.SendData(0)
        elif (self.canMessage[3] == '817'): # 2nd gear
            self.vehicleGearActive.SendData(1)
        elif (self.canMessage[3] == '827'): # 3rd gear
            self.vehicleGearActive.SendData(2)
        elif (self.canMessage[3] == '837'): # 4th gear
            self.vehicleGearActive.SendData(3)
        elif (self.canMessage[3] == '847'): # 5th gear
            self.vehicleGearActive.SendData(4)
        elif (self.canMessage[3] == '857'): # 6th gear
            self.vehicleGearActive.SendData(5)
        elif (self.canMessage[3] == '867'): # 6th gear
            self.vehicleGearActive.SendData(5)
    
    def __add_to_sensor(self, canId): # canMsg contains byte data from ID
        switcher = {
            201: self.speed_ford,
            205: self.brake_applied_ford,
            230: self.gear_active_ford
        }

        func = switcher.get(canId, lambda: "Invalid CAN ID")
        print(func())

