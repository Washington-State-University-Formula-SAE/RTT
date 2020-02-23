import os
import can
from vehicleMQTT import *

class CANInterface():
    def __init__(self):
        self.vehicleRPM = vehicleRPM()
        self.vehicleSpeed = vehicleSpeed()
        self.acceleratorPosition = acceleratorPosition()        
        self.brakeActive = brakeActive()

    def start_receive(self):
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

    def __AddToSensor(self, message):
            if message[3] == '0631': # accelerator position, rpm, speed
                # speedMessage = (((int(message[7], 16)*256)+int(message[8], 16)) / 100) - 100 # km/h
                # rpmMessage = ((int(message[3], 16)+int(message[4], 16)))
                # acceleratorMessage = (int(message[9], 16))
                speedMessage = 45
                rpmMessage = 3432
                acceleratorMessage = 50 # max is 200
                self.vehicleSpeed.SendData(speedMessage)
                self.vehicleRPM.SendData(rpmMessage)
                self.acceleratorPosition.SendData(acceleratorMessage)
            elif message[3] == '205':
                brakeApplied = (int(message[9], 16))
                self.brakeActive.SendData(brakeApplied)


