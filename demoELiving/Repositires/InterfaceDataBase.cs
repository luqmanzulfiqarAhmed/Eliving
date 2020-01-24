

using System.Threading.Tasks;

namespace demoELiving.Repositires
{
    public  interface InterfaceDataBase
    {
        
        Task <object> insert(object obj);
        Task <object> update(string id, object obj);
        Task <object> delete(string id);
        Task <object> retrieveAll(string Id);
        Task <object> retrieve(string id);
                          
    }
}
