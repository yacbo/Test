using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using TelContractDTO;
using DeviceManager;
using Spring.Context.Support;
using System;
namespace TelContract
{
    class Contract:IContract
    {
        #region 属性
        private IENVManager m_EnvManager = null;
        public IENVManager EnvManager
        {
            get
            {
                if (m_EnvManager == null)
                    m_EnvManager = ContextRegistry.GetContext().GetObject("envManager") as IENVManager;
                return m_EnvManager;
            }
        }

        #endregion
        public string GetServerTime(string param)
        {
            Console.WriteLine(param);
            /* //转成UTF-8编码的字符串
            UTF8Encoding utf8 = new UTF8Encoding();
            Byte[] encodedBytes = utf8.GetBytes(DateTime.Now.ToString("F"));
            String decodedString = utf8.GetString(encodedBytes);
            return decodedString;
             */
            return DateTime.Now.ToString("F");
        }
        public string GetId(string id)
        {
            return id.ToString();
        }
       
        /// <summary>
        /// 获取环境参数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EnvironmentParamDTO GetEnvironmentParam(string id)
        {
            try
            {
                return this.EnvManager.GetEnvironmentPara(id);    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
