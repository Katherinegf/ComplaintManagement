using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfAppDataBase.Context;
using WpfAppDataBase.MVVM.Models;
using WpfAppDataBase.MVVM.Models.Entities;

namespace WpfAppDataBase.Services
{
    public static class CaseService
    {
        private static DataContext _context = new DataContext();

        public static ObservableCollection<Case> cases = new ObservableCollection<Case>();
        public static ObservableCollection<Comment> comments = new ObservableCollection<Comment>();

        public static async Task SaveErrandAsync(Case @case)
        {

            {
                var caseEntity = new CaseEntity
                {
                    CaseNumber= @case.CaseNumber,
                    EntryDate = @case.EntryDate,
                    CustomerName = @case.CustomerName,
                    CustomerEmail = @case.CustomerEmail,
                    CustomerPhoneNumber = @case.CustomerPhoneNumber,
                    Description = @case.Description,
                    Status = "Ej påbärjad",
                   
                };

                _context.Add(caseEntity);
                await _context.SaveChangesAsync();
            }
        }

        public static async Task<IEnumerable<Case>> GetAllCasesAsync()
        {
            var _cases = new List<Case>();

            foreach (var _case in await _context.Cases.ToListAsync())
                _cases.Add(new Case
                {
                    CaseNumber= _case.CaseNumber,
                    EntryDate = _case.EntryDate,
                    CustomerName = _case.CustomerName,
                    CustomerEmail = _case.CustomerEmail,
                    CustomerPhoneNumber = _case.CustomerPhoneNumber,
                    Description = _case.Description,
                    Status = _case.Status
                });

            return _cases;
        }

        public static Case ConvertEntityToModel(CaseEntity @case) //GetCaseByCustomerIdAsync
        {
            if (@case != null)
                return new Case
                {
                    CaseNumber = @case.CaseNumber,
                    CustomerId = @case.Customer.Id,
                    EntryDate = @case.EntryDate,
                    CustomerName = @case.CustomerName,
                    CustomerEmail = @case.CustomerEmail,
                    CustomerPhoneNumber = @case.CustomerPhoneNumber,
                    Description = @case.Description,
                    Status = @case.Status,

                };
            else
                return null!;
        }

        public static async Task<CaseEntity?> GetCaseEntityAsync(string caseNumber)
        {
            return await _context.Cases.Include("Customer").Include("Address").FirstOrDefaultAsync(x => x.CaseNumber == caseNumber);
        }

        public static async Task<Case> GetCaseByCustomerIdAsync(string customerid)
        {
            var _case = await _context.Cases.Include("Customer").Include("Address").FirstOrDefaultAsync(x => x.Customer.Id.ToString() == customerid);
            if (_case != null)
                return ConvertEntityToModel(_case);
            else
                return null!;
        }

        public static async Task AddCommentToCaseAsync(string casenumber, Case @case)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == @case.CustomerId);
            var _case = await _context.Cases.FirstOrDefaultAsync(x => x.CaseNumber == casenumber);

            if (customer != null)
            {
                if (_case != null)
                {
                    var caseDesc = new Case                    
                    {
                        Comment = @case.Comment,
                    };

                    _context.Add(caseDesc);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public static async Task UpdateCaseStatus(string customerid, Case @case)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == @case.CustomerId);
            var _case = await _context.Cases.FirstOrDefaultAsync(x => x.Customer.Id.ToString() == customerid);

            if (customer != null) // om kunden finns gör detta
            {
                if (_case != null) // om ärendet finns genom kundnummer gör detta
                {
                    if (!string.IsNullOrEmpty(@case.Status))
                        _case.Status = @case.Status;

                    _context.Update(_case);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public static async Task RemoveCaseAsync(string caseNumber)
        {
            var @case = await _context.Cases.FirstOrDefaultAsync(x => x.CaseNumber == caseNumber);
            if (@case != null)
            {
                _context.Remove(@case);
                await _context.SaveChangesAsync();
            }
        }

        public static ObservableCollection<Case> Cases()
        {
            return cases;
        }

        public static async Task SaveCommentAsync(string customerid, Comment comment)
        {
            var _case = await _context.Cases.FirstOrDefaultAsync(x => x.Customer.Id.ToString() == customerid);
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == comment.CustomerId);

            if (customer != null)
            {
                if (customer != null)
                {
                    var commentEntity = new CommentEntity
                    {
                        EntryTime = comment.EntryTime,
                        Description = comment.Description
                    };

                    _context.Add(commentEntity);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public static ObservableCollection<Comment> Comments()
        {
            return comments;
        }

        internal static Task SaveCaseAsync(Case @case)
        {
            throw new NotImplementedException();
        }
    }
}
