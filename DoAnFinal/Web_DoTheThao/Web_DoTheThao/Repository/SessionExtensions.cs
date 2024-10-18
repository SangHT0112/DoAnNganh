

using Newtonsoft.Json;

namespace Web_DoTheThao.Repository
{
	public static class SessionExtensions /*  Lớp này giúp lưu trữ và truy xuất các đối tượng phức tạp trong phiên (session) bằng cách sử dụng JSON */
	{
		public static void SetJson(this ISession session, string key, object value)
		{
			session.SetString(key, JsonConvert.SerializeObject(value));
		}
		public static T GetJson<T>(this ISession session,string key){
			var sessionData=session.GetString(key);
			return sessionData == null ? default(T) : JsonConvert.DeserializeObject<T>(sessionData);
		}
	}
}
