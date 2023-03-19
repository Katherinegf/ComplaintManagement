using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppDataBase.Context;
using WpfAppDataBase.MVVM.Models;
using WpfAppDataBase.MVVM.Models.Entities;

namespace WpfAppDataBase.Services
{
    public partial class AddressService
    {
        private static DataContext _context = new DataContext();

        public static ObservableCollection<Address> addresses = new ObservableCollection<Address>();

        public static async Task SaveAddressAsync(Address address)
        {
            var addressEntity = new AddressEntity
            {
                StreetName = address.StreetName,
                City = address.City,
                PostalCode = address.PostalCode,
            };

            _context.Add(addressEntity);
            await _context.SaveChangesAsync();
        }

        public static async Task<IEnumerable<Address>> GetAllAddressesAsync()
        {
            var _addresses = new List<Address>();

            foreach (var _address in await _context.Addresses.ToListAsync())
                _addresses.Add(new Address
                {
                    Id = _address.Id,
                    StreetName = _address.StreetName,
                    City = _address.City,
                    PostalCode = _address.PostalCode,
                });

            return _addresses;
        }

        public static async Task<Address> GetAddressAsync(int id)
        {
            var _address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == id);
            if (_address != null)
                return new Address
                {
                    Id = _address.Id,
                    StreetName = _address.StreetName,
                    City = _address.City,
                    PostalCode = _address.PostalCode,
                };
            else
                return null!;
        }

        public static async Task UpdateAddressAsync(int id, Address address)
        {
            var _addressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == id);
            if (_addressEntity != null)
            {
                if (!string.IsNullOrEmpty(address.StreetName))
                    _addressEntity.StreetName = address.StreetName;

                if (!string.IsNullOrEmpty(address.City))
                    _addressEntity.City = address.City;

                if (!string.IsNullOrEmpty(address.PostalCode))
                    _addressEntity.PostalCode = address.PostalCode;

                _context.Update(_addressEntity);
                await _context.SaveChangesAsync();
            }
        }

        public static async Task RemoveAddressAsync(int id)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == id);
            if (address != null)
            {
                _context.Remove(address);
                await _context.SaveChangesAsync();
            }
        }

        public static ObservableCollection<Address> Addresses()
        {
            return addresses;
        }

        public static Address ConvertEntityToModel(AddressEntity address)
        {
            return new Address
            {
                City= address.City,
                PostalCode= address.PostalCode,
                Id= address.Id,
                StreetName= address.StreetName,
            };
        }
    }
}

