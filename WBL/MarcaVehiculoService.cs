using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IMarcaVehiculoService
    {
        Task<IEnumerable<MarcaVehiculoEntity>> Get();
        Task<MarcaVehiculoEntity> GetById(MarcaVehiculoEntity entity);
    }

    public class MarcaVehiculoService : IMarcaVehiculoService
    {
        private readonly IDataAccess sql;

        public MarcaVehiculoService(IDataAccess _sql)
        {
            sql = _sql;
        }

        public async Task<IEnumerable<MarcaVehiculoEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<MarcaVehiculoEntity>("MarcaVehiculoObtener");

                return await result;

            }
            catch (Exception)
            {

                throw;
            }



        }

        public async Task<MarcaVehiculoEntity> GetById(MarcaVehiculoEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<MarcaVehiculoEntity>("MarcaVehiculoObtener", new
                {
                    entity.MarcaVehiculoId
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<DBEntity> Create(MarcaVehiculoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("MarcaVehiculoInsertar", new
                {
                    entity.Descripcion,
                    entity.Estado
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<DBEntity> Update(MarcaVehiculoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("MarcaVehiculoActualizar", new
                {
                    entity.MarcaVehiculoId,
                    entity.Descripcion,
                    entity.Estado
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<DBEntity> Delete(MarcaVehiculoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("MarcaVehiculoEliminar", new
                {
                    entity.MarcaVehiculoId
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }

    }
}
