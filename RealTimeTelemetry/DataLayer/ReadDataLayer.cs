using Models;
using System;
using System.Collections.Generic;

namespace DataLayer
{
    public class ReadDataLayer
    {
        private IDataReadContext _context;
        public ReadDataLayer()
        {
            _context = new SQLData();
        }

        // Engine RPM
        public VehicleRPM GetMostRecentVehicleRPM()
        {
            return _context.GetMostRecentVehicleRPM();
        }
        public IEnumerable<VehicleRPM> GetAllVehicleRPM()
        {
            return _context.GetAllVehicleRPM();
        }
        public IEnumerable<VehicleRPM> GetVehicleRPMBetweenTimes(DateTime start, DateTime end)
        {
            return _context.GetVehicleRPMBetweenTimes(start, end);
        }

        // Vehicle Speed
        public VehicleSpeed GetMostRecentVehicleSpeed()
        {
            return _context.GetMostRecentVehicleSpeed();
        }
        public IEnumerable<VehicleSpeed> GetAllVehicleSpeed()
        {
            return _context.GetAllVehicleSpeed();
        }
        public IEnumerable<VehicleSpeed> GetVehicleSpeedBetweenTimes(DateTime start, DateTime end)
        {
            return _context.GetVehicleSpeedBetweenTimes(start, end);
        }

        // Accelerator Position
        public AcceleratorPosition GetMostRecentAccelertorPosition()
        {
            return _context.GetMostRecentAccelatorPosition();
        }
        public IEnumerable<AcceleratorPosition> GetAllAcceleratorPosition()
        {
            return _context.GetAllAcceleratorPosition();
        }
        public IEnumerable<AcceleratorPosition> GetAcceleratorPositionBetweenTimes(DateTime start, DateTime end)
        {
            return _context.GetAcceleratorPositionBetweenTimes(start, end);
        }

        // Brake Active
        public BrakeActive GetMostRecentBrakeActive()
        {
            return _context.GetMostRecentBrakeActive();
        }
        public IEnumerable<BrakeActive> GetAllBrakeActive()
        {
            return _context.GetAllBrakeActive();
        }
        public IEnumerable<BrakeActive> GetBrakeActiveBetweenTimes(DateTime start, DateTime end)
        {
            return _context.GetBrakeActiveBetweenTimes(start, end);
        }

        // Gear Active
        public GearActive GetMostRecentGearActive()
        {
            return _context.GetMostRecentGearActive();
        }
        public IEnumerable<GearActive> GetAllGearActive()
        {
            return _context.GetAllGearActive();
        }
        public IEnumerable<GearActive> GetGearActiveBetweenTimes(DateTime start, DateTime end)
        {
            return _context.GetGearActiveBetweenTimes(start, end);
        }

        // Wheel Speed
        public WheelSpeed GetMostRecentWheelSpeed()
        {
            return _context.GetMostRecentWheelSpeed();
        }
        public IEnumerable<WheelSpeed> GetAllWheelSpeed()
        {
            return _context.GetAllWheelSpeed();
        }
        public IEnumerable<WheelSpeed> GetWheelSpeedBetweenTimes(DateTime start, DateTime end)
        {
            return _context.GetWheelSpeedBetweenTimes(start, end);
        }

        // Steering Position
        public SteeringPosition GetMostRecentSteeringPosition()
        {
            return _context.GetMostRecentSteeringPosition();
        }
        public IEnumerable<SteeringPosition> GetAllSteeringPosition()
        {
            return _context.GetAllSteeringPosition();
        }
        public IEnumerable<SteeringPosition> GetSteeringPositionBetweenTimes(DateTime start, DateTime end)
        {
            return _context.GetSteeringPositionBetweenTimes(start, end);
        }
    }
}
