import os
import can
from MQTT.vehicleMQTT import *

class CANInterface():
    def __init__(self):
        self.vehicleRPM = vehicleRPM()
        self.vehicleSpeed = vehicleSpeed()
        self.acceleratorPosition = acceleratorPosition()        
        self.brakeActive = brakeActive()

    def initializeInterface(self):
        os.system('sudo ip link set can0 type can bitrate 500000')
        os.system('sudo ifconfig can0 up')

    def startReceive(self):
        # CAN linux setup
        self.initializeInterface()

        can0 = can.interface.Bus(channel = 'can0', bustype = 'socketcan_ctypes')

        # receive messages
        while True:
            msg = can0.recv(30.0) # message timeout = 30s
            if msg:
                msg = str(msg).split() # split incoming message
                print (msg) 
                self.__addToSensor(msg)
            else:
                print('No message was received')

    def __addToSensor(self, message):
            if message[3] == '0631': # accelerator position, rpm, speed
                speedMessage = (((int(message[7], 16)*256)+int(message[8], 16)) / 100) - 100 # km/h
                rpmMessage = ((int(message[3], 16)+int(message[4], 16)))
                acceleratorMessage = (int(message[9], 16))
                self.vehicleSpeed.SendData(speedMessage)
                self.vehicleRPM.SendData(rpmMessage)
                self.acceleratorPosition.SendData(acceleratorMessage)
            elif message[3] == '205': # brake sensor
                brakeApplied = (int(message[9], 16))
                self.brakeActive.SendData(brakeApplied)


