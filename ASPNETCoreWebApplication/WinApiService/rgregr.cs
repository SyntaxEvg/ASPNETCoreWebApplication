//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.ServiceProcess;
//using System.Text;
//using System.Threading.Tasks;

//namespace ASPNETCoreWebApplication.WinApiService
//{
//	private static T[] GetServices<T>(string machineName, int serviceType, string group, Func<Interop.Advapi32.ENUM_SERVICE_STATUS_PROCESS, T> selector)
//	{
//		int num = 0;
//		T[] result;

//		using (SafeServiceHandle dataBaseHandleWithAccess = ServiceController.GetDataBaseHandleWithAccess(machineName, 4))
//		{
//			int num2;
//			int num3;
//			Interop.Advapi32.EnumServicesStatusEx(dataBaseHandleWithAccess, 0, serviceType, 3, IntPtr.Zero, 0, out num2, out num3, ref num, group);
//			IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)num2);
//			T[] array;
//			try
//			{
//				Interop.Advapi32.EnumServicesStatusEx(dataBaseHandleWithAccess, 0, serviceType, 3, intPtr, num2, out num2, out num3, ref num, group);
//				array = new T[num3];
//				for (int i = 0; i < num3; i++)
//				{
//					IntPtr ptr = (IntPtr)((long)intPtr + (long)(i * Marshal.SizeOf<Interop.Advapi32.ENUM_SERVICE_STATUS_PROCESS>()));
//					Interop.Advapi32.ENUM_SERVICE_STATUS_PROCESS enum_SERVICE_STATUS_PROCESS = new Interop.Advapi32.ENUM_SERVICE_STATUS_PROCESS();
//					Marshal.PtrToStructure<Interop.Advapi32.ENUM_SERVICE_STATUS_PROCESS>(ptr, enum_SERVICE_STATUS_PROCESS);
//					array[i] = selector(enum_SERVICE_STATUS_PROCESS);
//				}
//			}
//			finally
//			{
//				Marshal.FreeHGlobal(intPtr);
//			}
//			result = array;
//		}
//		return result;
//	}
//}
