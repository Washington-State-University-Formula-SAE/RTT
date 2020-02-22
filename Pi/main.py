from paho.mqtt import client as mqtt
import time
import ssl
import MQTTDevice

device_id = "EngineRPM"
device = MQTTDevice.MQTTDevice(device_id )
for i in range(100):
    time.sleep(2)
    device.SendMessage("helloWorld")
    
