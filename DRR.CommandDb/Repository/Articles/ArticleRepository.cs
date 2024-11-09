﻿using DRR.Application.Contracts.Repository.Articles;
using DRR.CommandDB;
using DRR.Domain.Articles;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.Articles
{
    class ArticleRepository : BaseRepository, IArticleRepository
    {
        public ArticleRepository(BaseProjectCommandDb db) : base(db)
        {
        }
        public async Task<Article> ReadArticleById(int id)
        {
            var result = await _Db.Articles.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<List<Article>> ReadArticleByUserId(int id)
        {
            var result = await _Db.Articles.Where(c => c.UserId == id).ToListAsync();

            return result;
        }
        public async Task<List<Article>> ReadArticleByArticleTypeId(int id)
        {
            var result = await _Db.Articles.Where(c => c.ArticleTypeId == id).ToListAsync();

            return result;
        }

        public async Task Create(Article Article)
        {
            await _Db.Articles.AddAsync(Article);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(Domain.Articles.Article Article)
        {
            var result = await this.ReadArticleById(Article.Id);

            result.Title = Article.Title;
            result.Desc = Article.Desc;
            result.ArticleTypeId = Article.ArticleTypeId;
            result.UserId = Article.UserId;
            result.Link = Article.Link;
            result.DRRFileId = Article.DRRFileId;
            result.Authors = Article.Authors;


            _Db.Articles.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.Articles.FirstOrDefaultAsync(n => n.Id == id);

            _Db.Articles.Remove(result);

            await _Db.SaveChangesAsync();
        }

    }

}