﻿using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Domain.Reserv
{
    public class Turn : Entity<int>
    {
        public Turn (int turnNumber,string stime ,string etime ,bool isFree, int gradeIsDone)
        {
            this.TurnNumber = turnNumber;
            this.Stime = stime;
            this.Etime = etime;
            this.IsFree = isFree;
            this.GradeIsDone = gradeIsDone;

        }
        public void Update(int turnNumber, string stime, string etime, bool isFree, int gradeIsDone)
        {
            this.TurnNumber = turnNumber;
            this.Stime = stime;
            this.Etime = etime;
            this.IsFree = isFree;
            this.GradeIsDone = gradeIsDone;

        }

        public int TurnNumber { get; set; } 
        public string Stime { get; set; } 
        public string Etime { get; set; }
        public bool IsFree { get; set; }
        public int GradeIsDone { get; set; }
    }
}
