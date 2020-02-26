from paho.mqtt import client as mqtt
import time
import ssl
import MQTT.MQTTDevice
from CANDataInterpreter import CANInterface

if __name__ == "__main__":
    can = CANInterface()
    com = "COM3"
    baud = 9600

    can.start_receive_serial(com, baud)
    
