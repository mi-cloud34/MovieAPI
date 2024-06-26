﻿using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions.Claims;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Aspects.Autofac
{
   
        public class SecuredOperation : MethodInterception
        {
            private readonly String[] _roles;
            private readonly IHttpContextAccessor _httpContextAccessor;
            public SecuredOperation(String roles)
            {
                _roles = roles.Split(',');
                _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            }

            protected override void OnBefore(IInvocation invocation)
            {
                var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
                foreach (var role in _roles)
                {
                    if (roleClaims.Contains(role))
                        return;
                }
                throw new Exception(Messages.AuthorizationDenied);
            }
        }
    }

