using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sedas.Core
{
	public static class DTOCopy
	{
		/// <summary>
		/// 소스 DTO로부터 타겟 DTO로 프로퍼티 값들을 복사하는 정적 메서드.
		/// 타겟 DTO의 프로퍼티 중 소스 DTO에 속하지 않는 프로퍼티들은 프로퍼티 타입의 기본값을 그대로 유지
		/// </summary>
		/// <param name="sourceDTO">소스 DTO 개체</param>
		/// <param name="targetType">타겟 DTO 타입</param>
		/// <param name="isPrefixRemove">타겟 DTO의 프로퍼티 명에 Prefix(V_, N_, D_)가 붙었을 경우 삭제할 것인지의 여부</param>
		/// <returns>타겟 DTO 타입형 개체를 반환</returns>
		public static object PropertyValueCopy(object sourceDTO, Type targetType, bool isPrefixRemove = false)
		{
			object targetDTO = Activator.CreateInstance(targetType);

			PropertyInfo[] sourceProperties = sourceDTO.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
			PropertyInfo[] targetProperties = targetType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

			foreach (PropertyInfo targetProperty in targetProperties)
			{
				if (targetProperty.CanWrite && targetProperty.GetSetMethod() != null)
				{
					if (targetProperty.Name.Equals("BASE_STATE"))
					{
						targetProperty.SetValue(targetDTO, System.Data.DataRowState.Added, null);
					}
					else
					{
						string propertyName = targetProperty.Name;
						if (isPrefixRemove)
						{
							if (propertyName.StartsWith("V_")) propertyName = propertyName.Substring(2);
							else if (propertyName.StartsWith("D_")) propertyName = propertyName.Substring(2);
							else if (propertyName.StartsWith("N_")) propertyName = propertyName.Substring(2);
						}
						PropertyInfo matchSourceProperty = sourceProperties.Where(p => p.Name == propertyName).FirstOrDefault();
						//// 인덱서인 경우 복사에서 제외
						//if (matchSourceProperty != null)
						//{
						//    ParameterInfo[] paramInfo = matchSourceProperty.GetIndexParameters();
						//    if (paramInfo != null && paramInfo.Length > 0)
						//        continue;
						//}
						if (matchSourceProperty != null && matchSourceProperty.GetGetMethod() != null && Type.Equals(GetCoreType(targetProperty.PropertyType), GetCoreType(matchSourceProperty.PropertyType)))
							targetProperty.SetValue(targetDTO, matchSourceProperty.GetValue(sourceDTO, null), null);
					}
				}
			}

			return targetDTO;
		}

		/// <summary>
		/// 소스 DTO로부터 타겟 DTO로 프로퍼티 값들을 복사하는 정적 메서드.
		/// </summary>
		/// <param name="sourceDTO">소스 DTO 개체</param>
		/// <param name="targetDTO">타겟 DTO 개체</param>
		/// <param name="isPrefixRemove">타겟 DTO의 프로퍼티 명에 Prefix(V_, N_, D_)가 붙었을 경우 삭제할 것인지의 여부</param>
		public static void PropertyValueCopy(object sourceDTO, object targetDTO, bool isPrefixRemove = false)
		{
			PropertyInfo[] sourceProperties = sourceDTO.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
			PropertyInfo[] targetProperties = targetDTO.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

			foreach (PropertyInfo targetProperty in targetProperties)
			{
				if (targetProperty.CanWrite && targetProperty.GetSetMethod() != null)
				{
					if (targetProperty.Name.Equals("BASE_STATE"))
					{
						targetProperty.SetValue(targetDTO, System.Data.DataRowState.Added, null);
					}
					else
					{
						string propertyName = targetProperty.Name;
						if (isPrefixRemove)
						{
							if (propertyName.StartsWith("V_")) propertyName = propertyName.Substring(2);
							else if (propertyName.StartsWith("D_")) propertyName = propertyName.Substring(2);
							else if (propertyName.StartsWith("N_")) propertyName = propertyName.Substring(2);
						}
						PropertyInfo matchSourceProperty = sourceProperties.Where(p => p.Name == propertyName).FirstOrDefault();
						//// 인덱서인 경우 복사에서 제외
						//if (matchSourceProperty != null)
						//{
						//    ParameterInfo[] paramInfo = matchSourceProperty.GetIndexParameters();
						//    if (paramInfo != null && paramInfo.Length > 0)
						//        continue;
						//}
						if (matchSourceProperty != null && matchSourceProperty.GetGetMethod() != null && Type.Equals(GetCoreType(targetProperty.PropertyType), GetCoreType(matchSourceProperty.PropertyType)))
							targetProperty.SetValue(targetDTO, matchSourceProperty.GetValue(sourceDTO, null), null);
					}
				}
			}
		}

		/// <summary>
		/// 형식의 내부 형식을 반환하는 정적 메서드.
		/// Nullable 타입일 경우 사용된 내부 형식을 알아냅니다.
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		private static Type GetCoreType(Type type)
		{
			if (type != null && IsNullable(type))
			{
				if (!type.IsValueType) return type;
				return Nullable.GetUnderlyingType(type);
			}
			return type;
		}

		/// <summary>
		/// null 값을 가질 수 있는 형식인지의 여부
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		private static bool IsNullable(Type type)
		{
			return !type.IsValueType || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>));
		}
	}
}
