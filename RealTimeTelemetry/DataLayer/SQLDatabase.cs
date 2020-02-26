using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SQLDatabase : IDataRead, IDataWrite
    {
        private TelematryContext _context;
        public SQLDatabase(TelematryContext context)
        {
            _context = context ?? throw new Exception("Telematry Context cannot be null!");
        }
        public SQLDatabase(string connectionString)
        {
            if (connectionString == "")
                throw new Exception("Connection string cannot be null");
            DbContextOptionsBuilder<TelematryContext> builder = new DbContextOptionsBuilder<TelematryContext>();
            builder.UseSqlServer(connectionString);
            _context = new TelematryContext(builder.Options);
        }
        #region Read

        #region AcceleratorPosition
        public IQueryable<AcceleratorPosition> GetAcceleratorPositionBetweenTimes(DateTime start, DateTime end)
        {
            return _context.AcceleratorPosition.AsNoTracking().Where(u => u.TimeStamp >= start && u.TimeStamp <= end);
        }

        public IQueryable<AcceleratorPosition> GetAllAcceleratorPosition()
        {
            return _context.AcceleratorPosition.AsNoTracking();
        }
        public async Task<AcceleratorPosition> GetMostRecentAccelatorPositionAsync()
        {
            return await _context.AcceleratorPosition.AsNoTracking().FirstOrDefaultAsync();
        }
        #endregion


        #region BrakeActive
        public IQueryable<BrakeActive> GetAllBrakeActive()
        {
            return _context.BrakeActive.AsNoTracking();
        }
        public IQueryable<BrakeActive> GetBrakeActiveBetweenTimes(DateTime start, DateTime end)
        {
            return _context.BrakeActive.AsNoTracking().Where(u => u.TimeStamp >= start && u.TimeStamp <= end);
        }
        public async Task<BrakeActive> GetMostRecentBrakeActiveAsync()
        {
            return await _context.BrakeActive.AsNoTracking().FirstOrDefaultAsync();
        }
        #endregion


        #region VehicleRPM
        public IQueryable<VehicleRPM> GetAllVehicleRPM()
        {
            return _context.VehicleRPM.AsNoTracking();
        }
        public IQueryable<VehicleRPM> GetVehicleRPMBetweenTimes(DateTime start, DateTime end)
        {
            return _context.VehicleRPM.AsNoTracking().Where(u => u.TimeStamp >= start && u.TimeStamp <= end);
        }
        public async Task<VehicleRPM> GetMostRecentVehicleRPMAsync()
        {
            return await _context.VehicleRPM.AsNoTracking().FirstOrDefaultAsync();
        }
        #endregion


        #region GearActive
        public IQueryable<GearActive> GetAllGearActive()
        {
            return _context.GearActive.AsNoTracking();
        }
        public IQueryable<GearActive> GetGearActiveBetweenTimes(DateTime start, DateTime end)
        {
            return _context.GearActive.AsNoTracking().Where(u => u.TimeStamp >= start && u.TimeStamp <= end);
        }

        public async Task<GearActive> GetMostRecentGearActiveAsync()
        {
            return await _context.GearActive.AsNoTracking().FirstOrDefaultAsync();
        }
        #endregion


        #region SteeringPosition
        public IQueryable<SteeringPosition> GetAllSteeringPosition()
        {
            return _context.SteeringPosition.AsNoTracking();
        }
        public IQueryable<SteeringPosition> GetSteeringPositionBetweenTimes(DateTime start, DateTime end)
        {
            return _context.SteeringPosition.AsNoTracking().Where(u => u.TimeStamp >= start && u.TimeStamp <= end);
        }
        public async Task<SteeringPosition> GetMostRecentSteeringPositionAsync()
        {
            return await _context.SteeringPosition.AsNoTracking().FirstOrDefaultAsync();
        }
        #endregion


        #region VehicleSpeed
        public IQueryable<VehicleSpeed> GetAllVehicleSpeed()
        {
            return _context.VehicleSpeed.AsNoTracking();
        }
        public IQueryable<VehicleSpeed> GetVehicleSpeedBetweenTimes(DateTime start, DateTime end)
        {
            return _context.VehicleSpeed.AsNoTracking().Where(u => u.TimeStamp >= start && u.TimeStamp <= end);
        }

        public async Task<VehicleSpeed> GetMostRecentVehicleSpeedAsync()
        {
            return await _context.VehicleSpeed.AsNoTracking().FirstOrDefaultAsync();
        }
        #endregion


        #region WheelSpeed
        public IQueryable<WheelSpeed> GetAllWheelSpeed()
        {
            return _context.WheelSpeed.AsNoTracking();
        }
        public IQueryable<WheelSpeed> GetWheelSpeedBetweenTimes(DateTime start, DateTime end)
        {
            return _context.WheelSpeed.AsNoTracking().Where(u => u.TimeStamp >= start && u.TimeStamp <= end);
        }
        public async Task<WheelSpeed> GetMostRecentWheelSpeedAsync()
        {
            return await _context.WheelSpeed.AsNoTracking().FirstOrDefaultAsync();
        }
        #endregion


        #region EngineTemperature
        public async Task<EngineTemperature> GetMostRecentEngineTemperatureAsync()
        {
            return await _context.EngineTemperature.AsNoTracking().FirstOrDefaultAsync();

        }
        public IQueryable<EngineTemperature> GetAllEngineTemperature()
        {
            return _context.EngineTemperature.AsNoTracking();

        }
        public IQueryable<EngineTemperature> GetEngineTemperatureBetweenTimes(DateTime start, DateTime end)
        {
            return _context.EngineTemperature.AsNoTracking().Where(u => u.TimeStamp >= start && u.TimeStamp <= end);
        }
        #endregion
        #endregion

        #region Write
        #region AcceleratorPosition
        public async Task<AcceleratorPosition> InsertAcceleratorPositionAsync(AcceleratorPosition acceleratorPosition)
        {
            _context.AcceleratorPosition.Add(acceleratorPosition);
            await _context.SaveChangesAsync();
            _context.Entry(acceleratorPosition).State = EntityState.Detached;
            return acceleratorPosition;
        }

        public async Task<List<AcceleratorPosition>> InsertAcceleratorPositionAsync(List<AcceleratorPosition> acceleratorPosition)
        {
            _context.AcceleratorPosition.AddRange(acceleratorPosition);
            await _context.SaveChangesAsync();
            _context.Entry(acceleratorPosition).State = EntityState.Detached;
            return acceleratorPosition;
        }
        #endregion


        #region BrakeActive
        public async Task<BrakeActive> InsertBrakeActiveAsync(BrakeActive brakeActive)
        {
            _context.BrakeActive.Add(brakeActive);
            await _context.SaveChangesAsync();
            _context.Entry(brakeActive).State = EntityState.Detached;
            return brakeActive;
        }

        public async Task<List<BrakeActive>> InsertBrakeActiveAsync(List<BrakeActive> brakeActive)
        {
            _context.BrakeActive.AddRange(brakeActive);
            await _context.SaveChangesAsync();
            _context.Entry(brakeActive).State = EntityState.Detached;
            return brakeActive;
        }
        #endregion


        #region VehicleRPM
        public async Task<VehicleRPM> InsertVehicleRPMAsync(VehicleRPM VehicleRPM)
        {
            _context.VehicleRPM.Add(VehicleRPM);
            await _context.SaveChangesAsync();
            _context.Entry(VehicleRPM).State = EntityState.Detached;
            return VehicleRPM;
        }

        public async Task<List<VehicleRPM>> InsertVehicleRPMAsync(List<VehicleRPM> VehicleRPMs)
        {
            _context.VehicleRPM.AddRange(VehicleRPMs);
            await _context.SaveChangesAsync();
            _context.Entry(VehicleRPMs).State = EntityState.Detached;
            return VehicleRPMs;
        }
        #endregion


        #region GearActive
        public async Task<GearActive> InsertGearActiveAsync(GearActive gearActive)
        {
            _context.GearActive.Add(gearActive);
            await _context.SaveChangesAsync();
            _context.Entry(gearActive).State = EntityState.Detached;
            return gearActive;
        }

        public async Task<List<GearActive>> InsertGearActiveAsync(List<GearActive> gearActive)
        {
            _context.GearActive.AddRange(gearActive);
            await _context.SaveChangesAsync();
            _context.Entry(gearActive).State = EntityState.Detached;
            return gearActive;
        }
        #endregion


        #region SteeringPosition
        public async Task<SteeringPosition> InsertSteeringPositionAsync(SteeringPosition steeringPosition)
        {
            _context.SteeringPosition.Add(steeringPosition);
            await _context.SaveChangesAsync();
            _context.Entry(steeringPosition).State = EntityState.Detached;
            return steeringPosition;
        }

        public async Task<List<SteeringPosition>> InsertSteeringPositionAsync(List<SteeringPosition> steeringPosition)
        {
            _context.SteeringPosition.AddRange(steeringPosition);
            await _context.SaveChangesAsync();
            _context.Entry(steeringPosition).State = EntityState.Detached;
            return steeringPosition;
        }
        #endregion


        #region VehicleSpeed
        public async Task<VehicleSpeed> InsertVehicleSpeedAsync(VehicleSpeed vehicleSpeed)
        {
            _context.VehicleSpeed.Add(vehicleSpeed);
            await _context.SaveChangesAsync();
            _context.Entry(vehicleSpeed).State = EntityState.Detached;
            return vehicleSpeed;
        }

        public async Task<List<VehicleSpeed>> InsertVehicleSpeedAsync(List<VehicleSpeed> vehicleSpeed)
        {
            _context.VehicleSpeed.AddRange(vehicleSpeed);
            await _context.SaveChangesAsync();
            _context.Entry(vehicleSpeed).State = EntityState.Detached;
            return vehicleSpeed;
        }
        #endregion


        #region WheelSpeed
        public async Task<WheelSpeed> InsertWheelSpeedAsync(WheelSpeed wheelSpeed)
        {
            _context.WheelSpeed.Add(wheelSpeed);
            await _context.SaveChangesAsync();
            _context.Entry(wheelSpeed).State = EntityState.Detached;
            return wheelSpeed;
        }

        public async Task<List<WheelSpeed>> InsertWheelSpeedAsync(List<WheelSpeed> wheelSpeed)
        {
            _context.WheelSpeed.AddRange(wheelSpeed);
            await _context.SaveChangesAsync();
            _context.Entry(wheelSpeed).State = EntityState.Detached;
            return wheelSpeed;
        }
        #endregion


        #region EngineTemperature
        public async Task<EngineTemperature> InsertEngineTemperatureAsync(EngineTemperature engineTemperature)
        {
            _context.EngineTemperature.Add(engineTemperature);
            await _context.SaveChangesAsync();
            _context.Entry(engineTemperature).State = EntityState.Detached;
            return engineTemperature;
        }

        public async Task<List<EngineTemperature>> InsertEngineTemperatureAsync(List<EngineTemperature> engineTemperature)
        {
            _context.EngineTemperature.AddRange(engineTemperature);
            await _context.SaveChangesAsync();
            _context.Entry(engineTemperature).State = EntityState.Detached;
            return engineTemperature;
        }
        #endregion
        #endregion
    }
}
