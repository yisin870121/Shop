using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace MCSDD12.Models
{
    public class MCSDD12Context:DbContext  //繼承DB Context類別
    {
        public MCSDD12Context():base("name=MCSDD12Connection")
        {

        }

        //這段的用意是要指定連線資料庫的字串(DB First在用的)
        //override:繼承，繼承別人的類別
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    throw new UnintentionalCodeFirstException();
        //}

        
        //描述資料庫裡面的資料表
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Shippers> Shippers { get; set; }
        public virtual DbSet<PayTypes> PayTypes { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
    }
}