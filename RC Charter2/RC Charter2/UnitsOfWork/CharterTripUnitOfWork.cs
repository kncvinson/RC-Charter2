﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RC_Charter2.Models;
using RC_Charter2.Repositories;

namespace RC_Charter2.UnitsOfWork
{
	public class CharterTripUnitOfWork : IDisposable
	{
		private RC_Charter2Context _context;
		private IRepository<CharterTrip> _charterTripRepository { get; set; }
		private IRepository<Flight> _flightRepository { get; set; }
		private IRepository<Aircraft> _aircraftRepository { get; set; }
		private IRepository<CrewAssignment> _crewAssignmentRepository { get; set; }
		private IRepository<Employee> _employeeRepository { get; set; }
		private IRepository<CharterFlightCharge> _charterFlightChargeRepository { get; set; }
		private IRepository<BalanceHistory> _balanceHistoryRepository { get; set; }
		private IRepository<Customer> _customerRepository { get; set; }

		public CharterTripUnitOfWork(IRepository<Customer> customerRepository ,IRepository<BalanceHistory> balanceHistoryRepository, IRepository<CharterTrip> charterTripRepository, IRepository<Flight> flightRepository, IRepository<Aircraft> aircraftRepository, IRepository<CrewAssignment> crewAssignmentRepository, IRepository<Employee> employeeRepository, IRepository<CharterFlightCharge> charterFlightChargeRepository)
		{
			_charterTripRepository = charterTripRepository;
			_flightRepository = flightRepository;
			_aircraftRepository = aircraftRepository;
			_crewAssignmentRepository = crewAssignmentRepository;
			_employeeRepository = employeeRepository;
			_charterFlightChargeRepository = charterFlightChargeRepository;
			_balanceHistoryRepository = balanceHistoryRepository;
			_customerRepository = customerRepository;
		}

		public CharterTripUnitOfWork()
		{
			_context = new RC_Charter2Context();
			_charterTripRepository = new EfRepository<CharterTrip>(_context);
			_flightRepository = new EfRepository<Flight>(_context);
			_aircraftRepository = new EfRepository<Aircraft>(_context);
			_crewAssignmentRepository = new EfRepository<CrewAssignment>(_context);
			_employeeRepository = new EfRepository<Employee>(_context);
			_charterFlightChargeRepository = new EfRepository<CharterFlightCharge>(_context);
			_balanceHistoryRepository = new EfRepository<BalanceHistory>(_context);
			_customerRepository = new EfRepository<Customer>(_context);
		}

		public void AddCharterTrip(CharterTrip charterTrip, Aircraft aircraft, Customer customer)
		{
			charterTrip.AircraftNumber = aircraft.AircraftNumber;
			charterTrip.CustomerId = customer.CustomerId;
			_charterTripRepository.Add(charterTrip);
			_charterTripRepository.SaveChanges();
		}

		public void AddCustomer(Customer customer)
		{
			_customerRepository.Add(customer);
			_customerRepository.SaveChanges();
		}

		public void DeleteCustomer(Customer customer)
		{
			_customerRepository.Remove(customer);
			_customerRepository.SaveChanges();
		}

		public void DeleteCharterTrip(CharterTrip charterTrip)
		{
			_charterTripRepository.Remove(charterTrip);
			_charterTripRepository.SaveChanges();
		}

		public void DeleteCrewAssignment(CrewAssignment crewAssignment)
		{
			_crewAssignmentRepository.Remove(crewAssignment);
			_crewAssignmentRepository.SaveChanges();
		}

		public void UpdateCrewAssignment(CrewAssignment crewAssignment)
		{
			_crewAssignmentRepository.Update(crewAssignment);
			_crewAssignmentRepository.SaveChanges();
		}

		public void DeleteFlight(Flight flight)
		{
			_flightRepository.Remove(flight);
			_flightRepository.SaveChanges();	
		}

		public void DeleteCharterFlightCharge(CharterFlightCharge charterFlightCharge)
		{
			var charterTrip = _charterTripRepository.Get(c => c.CharterTripId == charterFlightCharge.CharterTripId);
			charterTrip.TotalCharge -= charterFlightCharge.Amount;
			charterTrip.RemainingBalance -= charterFlightCharge.Amount;
			_charterTripRepository.Update(charterTrip);
			_charterTripRepository.SaveChanges();
			_charterFlightChargeRepository.Remove(charterFlightCharge);
			_charterFlightChargeRepository.SaveChanges();
		}

		public void DeleteBalanceHistory(BalanceHistory balanceHistory)
		{
			_balanceHistoryRepository.Remove(balanceHistory);
			_balanceHistoryRepository.SaveChanges();
		}

		public void AddFlightToCharterTrip(Flight flight, CharterTrip charterTrip)
		{
			flight.CharterTripId = charterTrip.CharterTripId;
			_flightRepository.Add(flight);
			_flightRepository.SaveChanges();
		}

		public void AddCrewMember(CrewAssignment crewAssignment, Employee employee, CharterTrip charterTrip)
		{
			crewAssignment.EmployeeId = employee.EmployeeId;
			crewAssignment.CharterTripId = charterTrip.CharterTripId;
			_crewAssignmentRepository.Add(crewAssignment);
			_crewAssignmentRepository.SaveChanges();
		}

		public void AddCharterFlightCharge(CharterFlightCharge charterFlightCharge, CharterTrip charterTrip)
		{
			charterFlightCharge.CharterTripId = charterTrip.CharterTripId;
			charterTrip.TotalCharge += charterFlightCharge.Amount;
			charterTrip.RemainingBalance += charterFlightCharge.Amount;
			_charterTripRepository.Update(charterTrip);
			_charterTripRepository.SaveChanges();
			_charterFlightChargeRepository.Add(charterFlightCharge);
			_charterFlightChargeRepository.SaveChanges();
		}

		public void UpdateCharterFlightCharge(CharterFlightCharge charterFlightCharge)
		{
			_charterFlightChargeRepository.Update(charterFlightCharge);
			_charterFlightChargeRepository.SaveChanges();
		}

		public void AddBalanceHistory(BalanceHistory balanceHistory, CharterTrip charterTrip)
		{
			balanceHistory.CharterTripId = charterTrip.CharterTripId;
			_balanceHistoryRepository.Add(balanceHistory);
			_balanceHistoryRepository.SaveChanges();
		}

		public void UpdateCharterTrip(CharterTrip charterTrip)
		{
			_charterTripRepository.Update(charterTrip);
			_charterTripRepository.SaveChanges();
		}

		public void UpdateCustomer(Customer customer)
		{
			_customerRepository.Update(customer);
			_customerRepository.SaveChanges();
		}

		public void UpdateFlight(Flight flight)
		{
			_flightRepository.Update(flight);
			_flightRepository.SaveChanges();
		}

		public IEnumerable<CharterTrip> GetCharterTrips(Expression<Func<CharterTrip, bool>> query)
		{
			return _charterTripRepository.GetRange(query);

		}

		public CharterTrip GetCharterTrip(Expression<Func<CharterTrip, bool>> query)
		{
			return _charterTripRepository.Get(query);
		}

		public IEnumerable<CharterTrip> GetAllCharterTrips()
		{
			return GetCharterTrips(c => true);
		}

		public IEnumerable<Flight> GetFlights(Expression<Func<Flight, bool>> query)
		{
			return _flightRepository.GetRange(query);
		}

		public IEnumerable<CharterFlightCharge> GetCharterFlightCharges(Expression<Func<CharterFlightCharge, bool>> query)
		{
			return _charterFlightChargeRepository.GetRange(query);
		}

		public CharterFlightCharge GetCharterFlightCharge(Expression<Func<CharterFlightCharge, bool>> query)
		{
			return _charterFlightChargeRepository.Get(query);
		}

		public IEnumerable<BalanceHistory> GetBalanceHistories(Expression<Func<BalanceHistory, bool>> query)
		{
			return _balanceHistoryRepository.GetRange(query);
		}

		public IEnumerable<CrewAssignment> GetCrewAssignments(Expression<Func<CrewAssignment, bool>> query)
		{
			var crewAssignments = _crewAssignmentRepository.GetRange(query);
			var employees = new List<Employee>();

			foreach (var crewAssignment in crewAssignments)
			{
				employees.Add(_employeeRepository.Get(c => c.EmployeeId == crewAssignment.EmployeeId));
			}

			return crewAssignments;
		}

		public CrewAssignment GetCrewAssignment(Expression<Func<CrewAssignment, bool>> query)
		{
			return _crewAssignmentRepository.Get(query);
		}

		public int GetCustomerCount()
		{
			return _customerRepository.Query().Count();
		}

		public IEnumerable<Customer> GetCustomersByPage(int itemPerPage, int page)
		{
			return _customerRepository.Query()
				.Skip(itemPerPage * (page - 1))
				.Take(itemPerPage)
				.ToList();
		}

		public IEnumerable<Customer> GetAllCustomers()
		{
			return _customerRepository.GetRange(c => true);
		}

		public Customer GetCustomer(Expression<Func<Customer, bool>> query)
		{
			return _customerRepository.Get(query);
		}

		private bool _isDisposing;
		private bool _isDisposed;

		public void Dispose()
		{
			if (!_isDisposing)
			{
				_isDisposing = true;
				if (!_isDisposed)
				{
					_context?.Dispose();
					_isDisposed = true;
				}
			}
		}
	}
}
