#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace CSObjectWrap
{
    using Utils = XLua.Utils;
    public class MickeyUtilsMEventWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Utils.BeginObjectRegister(typeof(MickeyUtils.MEvent), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			Utils.EndObjectRegister(typeof(MickeyUtils.MEvent), L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(typeof(MickeyUtils.MEvent), L, __CreateInstance, 4, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "Send", _m_Send_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Bind", _m_Bind_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Dispatch", _m_Dispatch_xlua_st_);
            
			
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UnderlyingSystemType", typeof(MickeyUtils.MEvent));
			
			
			Utils.EndClassRegister(typeof(MickeyUtils.MEvent), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					MickeyUtils.MEvent __cl_gen_ret = new MickeyUtils.MEvent();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to MickeyUtils.MEvent constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Send_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string e = LuaAPI.lua_tostring(L, 1);
                    
                    MickeyUtils.MEvent.Send( e );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Bind_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string e = LuaAPI.lua_tostring(L, 1);
                    MickeyUtils.MEvent.EventFunc ef = translator.GetDelegate<MickeyUtils.MEvent.EventFunc>(L, 2);
                    
                    MickeyUtils.MEvent.Bind( e, ef );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Dispatch_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    MickeyUtils.MEvent.Dispatch(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
