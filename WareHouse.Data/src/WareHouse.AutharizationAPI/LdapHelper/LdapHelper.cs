﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.AutharizationAPI.LdapHelper.Models;
using Novell.Directory.Ldap;

namespace WareHouse.AutharizationAPI.LdapHelper
{
    public class LdapHelper : ILdapHelper, IDisposable
    {
        private LdapConnection connection = new LdapConnection();
        private string baseSearchCatalog;

        public bool isConnected
        {
            get
            {
                return connection.Connected;
            }
        }
        public LdapHelper(string baseSearchCatalog)
        {
            this.baseSearchCatalog = baseSearchCatalog;
        }

        public LdapHelper(string baseSearchCatalog, string host, int port)
        {
            this.baseSearchCatalog = baseSearchCatalog;
            Connect(host, port);
        }

        public bool Connect(string host, int port)
        {
            try
            {
                connection.Connect(host, port);
            }
            catch(Exception e)
            {
                return false;
            }

            return true;
        }

        public void Disconnect()
        {
            if (!isConnected)
                connection.Disconnect();
        }

        public void Dispose()
        {
            Disconnect();
        }

        public LdapUser Login(string username, string password)
        {            
            try
            {
                connection.Bind(username, password);
            }
            catch(Exception e)
            {
                return null;
            }

            return GetUserByName(username);
        }

        public LdapUser GetUserByName(string username)
        {
            var user = GetLdapUser(username);

            if (user == null)
            {
                return null;
            }

            var roles = GetUserRoles(username);

            return new LdapUser
            {
                Roles = roles,
                UserName = username
            };                  
        }

        private IEnumerable<string> GetUserRoles(string username)
        {
            var user = GetLdapUser(username);

            if (user == null)
            {
                return null;
            }

            var attribute = user.getAttribute("objectClass");

            return attribute.StringValueArray;
        }       

        private LdapEntry GetLdapUser(string username)
        {
            try
            {
                var ldapSearchResult = connection.Search(baseSearchCatalog, LdapConnection.SCOPE_SUB, $"(&(userPrincipalName={username}))", null, false);
                var user = ldapSearchResult.next();
                return user;
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
