using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppDataBase.Context;
using WpfAppDataBase.MVVM.Models.Entities;
using WpfAppDataBase.MVVM.Models;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore;

namespace WpfAppDataBase.Services
{
    public static class CommentService

    {
        private static DataContext _context = new DataContext();

        public static ObservableCollection<Comment> comments = new ObservableCollection<Comment>();

        public static async Task SaveCommentAsync(Comment comment, string caseNumber)
        {
            CaseEntity? @case = await CaseService.GetCaseEntityAsync(caseNumber);

            if (@case == null)
                throw new NullReferenceException("No such case");

            var commentEntity = new CommentEntity
            {
                Id = comment.Id,
                Created = DateTime.Now,
                Description = comment.Description,
                Case = @case
            };

            _context.Add(commentEntity);
            await _context.SaveChangesAsync();
        }

        public static async Task<IEnumerable<Comment>> GetCommentsAsync()
        {
            var _comments = new List<Comment>();

            foreach (var _comment in await _context.Comments.ToListAsync())
                _comments.Add(new Comment
                {
                    Id = _comment.Id,
                    Created = DateTime.Now,
                    Description = _comment.Description,
                });
            return _comments;
        }
        public static async Task UpdateCommentAsync(string caseNumber, Comment comment)
        {
            var commentEnity = await _context.Comments.FirstOrDefaultAsync((c) => c.Case.CaseNumber == caseNumber);
            if (commentEnity != null)
            {
                if (!string.IsNullOrEmpty(comment.Description)) // varför vill de inte vara små?
                    commentEnity.Description = comment.Description;

                _context.Update(commentEnity);
                await _context.SaveChangesAsync();
            }
        }

        public static async Task RemoveCommentAsync(int id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync((x) => x.Id == id);
            if (comment != null)
            {
                _context.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }

        public static ObservableCollection<Comment> Comments()
        {
            return comments;
        }
    }
}
