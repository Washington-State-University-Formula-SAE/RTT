from paho.mqtt import client as mqtt
import time
import ssl
import MQTT.MQTTDevice
from can_receive import CANInterface

if __name__ == "__main__":
    can = CANInterface()
    can.start_receive_serial()
    
