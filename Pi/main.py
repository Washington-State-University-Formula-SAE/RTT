from paho.mqtt import client as mqtt
import time
import ssl
import MQTTDevice
from CANDataInterpreter import CANInterface

if __name__ == "__main__":
    can = CANInterface()
    
