﻿using System.Collections;
using Garage.Abstraction;

namespace Garage;

public class Garage<T>: IEnumerable<T> where T: Vehicle
{
    private T[] _vehicles;

    private int FindFirstEmptySlot() =>
        Array.IndexOf(_vehicles, null);

    public bool IsFull() =>
        FindFirstEmptySlot() == -1;

    private bool IsVehicleParked(string registrationNO) => 
                    _vehicles.Any(v => v != null && v.RegistrationNO == registrationNO);

    public Garage(int capacity) {
        if (capacity <= 0)
            throw new ArgumentException("Capacity must be positive.");

        _vehicles = new T[capacity];
    }


    public Garage(int capacity, List<T> vehicles)
    {
        if (capacity <= 0)
            throw new ArgumentException("Capacity must be positive.");
        if (vehicles.Count > capacity)
            throw new ArgumentException("Max capacity exceeted");

        _vehicles = new T[capacity];

        for (int i = 0; i < vehicles.Count; i++)
            _vehicles[i] = vehicles[i];

    }


    public bool Park(T vehicle) {

        if (IsVehicleParked(vehicle.RegistrationNO))
            return false; // Vehicle already parked

        int emptySlot = FindFirstEmptySlot();
        if (emptySlot == -1)
            return false; // Garage full

        _vehicles[emptySlot] = vehicle;
        return true;
    }


    public bool Leave(string registrationNO)
    {
        for (int i = 0; i < _vehicles.Length; i++)
        {
            if (_vehicles[i] != null && _vehicles[i].RegistrationNO == registrationNO)
            {
                _vehicles[i] = null;
                return true;
            }
        }
        return false;

    }


    public List<T> ListAll() => 
                                _vehicles
                                .Where(v => v != null)
                                .ToList();
   


    public IEnumerator<T> GetEnumerator()
    {
        foreach (var vehicle in _vehicles)
        {
            if (vehicle != null)
                yield return vehicle;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

}
