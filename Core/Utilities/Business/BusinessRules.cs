﻿using Core.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult? Run(params IResult[] logigcs)
        {
            foreach (var logic in logigcs)
            {    //logics : İş kurallarım.
                if (!logic.Success)
                {   //Başarısız olan iş kuralım olursa
                    return logic;   //Mevcut hata varsa onu döndürür.
                }
            }
            return null;    //tüm kurallarım başarılı ise null döndür.
        }
    }
}
