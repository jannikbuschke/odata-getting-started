﻿using Microsoft.AspNet.OData;
using System;
using System.Linq;

namespace Sample
{
    public class PersonsController : ODataController
    {
        private readonly DataContext ctx;

        public PersonsController(DataContext ctx)
        {
            this.ctx = ctx;
        }

        [EnableQuery]
        public SingleResult<Person> Get(Guid key)
        {
            return new SingleResult<Person>(ctx.Persons.Where(v => v.Id == key));
        }

        [EnableQuery]
        public IQueryable<Person> Get()
        {
            return ctx.Persons;
        }
    }
}
