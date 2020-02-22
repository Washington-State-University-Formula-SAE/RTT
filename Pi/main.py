from paho.mqtt import client as mqtt
import time
import ssl
import MQTTDevice

sas = "SharedAccessSignature sr=hackathon2020fsae.azure-devices.net&sig=u7v565eWC1MMstYzDcl5kCXepcluJh8zcFko7SKTieg%3D&skn=iothubowner&se=1582764444"
iot_hub_name = "hackathon2020fsae"
device_id = "EngineRPM"
device = MQTTDevice.MQTTDevice(sas,iot_hub_name, device_id )
for i in range(100):
    time.sleep(2)
    device.SendMessage("topic", "helloWorld")
    
