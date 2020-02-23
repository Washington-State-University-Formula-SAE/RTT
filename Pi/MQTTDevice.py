from paho.mqtt import client as mqtt
import time
import ssl

def on_subscribe(client, userdata, mid, granted_qos):
    print('Subscribed for m' + str(mid))

def on_connect(client, userdata, flags, rc):
    print("Connected with result code "+str(rc))

def on_message(client, userdata, message):
    print("Received message '" + str(message.payload) + "' on topic '" + message.topic + "' with QoS " + str(message.qos))

def on_log(client, userdata, level, buf):
    print("log: ",buf)

class MQTTDevice:
    sas_token = "SharedAccessSignature sr=hackathon2020fsae.azure-devices.net&sig=u7v565eWC1MMstYzDcl5kCXepcluJh8zcFko7SKTieg%3D&skn=iothubowner&se=1582764444"
    iot_hub_name = "hackathon2020fsae"
    def __init__(self, device_id):
        self.device_id = device_id

        self.client = mqtt.Client(client_id=device_id, protocol=mqtt.MQTTv311,  clean_session=False)
        self.client.on_log = on_log
        self.client.tls_set_context(context=None)

        self.username = "{}.azure-devices.net/{}/api-version=2018-06-30".format(self.iot_hub_name, self.device_id)
        self.client.username_pw_set(username=self.username, password=self.sas_token)

        # Connect to the Azure IoT Hub
        self.client.on_connect = on_connect
        self.client.connect(self.iot_hub_name+".azure-devices.net", port=8883)

        # Subscribing on the topic , 
        self.client.on_message = on_message
        self.client.on_subscribe = on_subscribe 
        self.client.subscribe("devices/{device_id}/messages/devicebound/#".format(device_id=device_id))
        self.client.subscribe("$iothub/twin/PATCH/properties/desired/#")
        self.client.subscribe("$iothub/methods/POST/#")

    def _SendMessage(self, payload):
        self.client.publish("devices/{device_id}/messages/events/".format(device_id=self.device_id), payload=payload, qos=0, retain=False)
    def _LoopForever(self):
        self.client.loop_forever()
