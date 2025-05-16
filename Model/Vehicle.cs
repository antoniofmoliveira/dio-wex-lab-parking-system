using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parking.Model
{
    /// <summary>
    /// Represents a vehicle
    /// </summary>
    /// <param name="licensePlate"></param>
    public class Vehicle(string licensePlate)
    {
        /// <summary>
        /// The vehicle license plate
        /// </summary>
        public string LicensePlate { get; } = licensePlate;
    }
}