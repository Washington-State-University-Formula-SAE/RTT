using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public interface IDataWrite
    {
        // Engine RPM
        VehicleRPM InsertVehicleRPM(VehicleRPM VehicleRPMs);
        List<VehicleRPM> InsertVehicleRPM(List<VehicleRPM> VehicleRPMs);

        // Vehicle Speed
        VehicleSpeed InsertVehicleSpeed(VehicleSpeed vehicleSpeed);
        List<VehicleSpeed> InsertVehicleSpeed(List<VehicleSpeed> vehicleSpeed);

        // Accelerator Position
        AcceleratorPosition InsertAcceleratorPosition(AcceleratorPosition acceleratorPosition);
        List<AcceleratorPosition> InsertAcceleratorPosition(List<AcceleratorPosition> acceleratorPosition);

        // Brake Active
        BrakeActive InsertBrakeActive(BrakeActive brakeActive);
        List<BrakeActive> InsertBrakeActive(List<BrakeActive> brakeActive);

        // Gear Active
        GearActive InsertGearActive(GearActive gearActive);
        List<GearActive> InsertGearActive(List<GearActive> gearActive);

        // Wheel Speed
        WheelSpeed InsertWheelSpeed(WheelSpeed wheelSpeed);
        List<WheelSpeed> InsertWheelSpeed(List<WheelSpeed> wheelSpeed);

        // Steering Position
        SteeringPosition InsertSteeringPosition(SteeringPosition steeringPosition);
        List<SteeringPosition> InsertSteeringPosition(List<SteeringPosition> steeringPosition);

        EngineTemperature InsertEngineTemperature(EngineTemperature engineTemperature);
        List<EngineTemperature> InsertEngineTemperature(List<EngineTemperature> engineTemperature);
    }
}
