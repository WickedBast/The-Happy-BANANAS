using HB.Core.Mapping;
using HB.Entity.Application;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.Mapping.Application
{
    public class UserMapping : BaseMap<User>
    {
        public UserMapping(EntityTypeBuilder<User> builder)
        {

        }
    }
}
