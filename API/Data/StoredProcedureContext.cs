using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using API.Entities;
// using Northwind.MSSQL.Models;

namespace API.Data
{

    public partial class DataContext
    {
        private StoredProcedureContext _procedures;

        public virtual StoredProcedureContext Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new StoredProcedureContext(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public StoredProcedureContext GetProcedures()
        {
            return Procedures;
        }
    }

    public class StoredProcedureContext
    {
        private readonly DataContext _context;
        public StoredProcedureContext(DataContext context)
        {
            _context = context;
        }

        public virtual async Task<List<GetUsernameByID>> GetUsernameByID(int UserID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "Id",
                    Value = UserID,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<GetUsernameByID>("EXEC @returnValue = [dbo].[GetUsernameByID] @Id", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }


        public virtual async Task<List<GetMasterBarangByKdBarang>> GetMasterBarangByKdBarang(string KdBarang, OutputParameter<string> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "KdBarang",
                    Value = KdBarang,
                    SqlDbType = System.Data.SqlDbType.Char,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<GetMasterBarangByKdBarang>("EXEC @returnValue = [dbo].[GetMasterBarangByKdBarang] @KdBarang", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }

    
}