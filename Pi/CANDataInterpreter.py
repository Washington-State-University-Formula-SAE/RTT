import os
import can
from EngineRPM import EngineRPM

class CANInterface():
    def __init__(self):
        self.EngineRPM = EngineRPM()

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
        if message[3] == "0631":
            hexMessage = ''.join(message[7:14])
            intMessage = int(hexMessage,16)
            self.EngineRPM.SendData(intMessage)

