workspace "Test Project"
	configurations { "Debug", "Release" }
	project "Test Project"
		location ""
		language "C#"
		dotnetframework "net8.0"
		kind "SharedLib"
		clr "Unsafe"

		files{
			"Assets/**.cs"
		}

		links {
			"C:/Development/Mule Engine/MuleScriptEngine/bin/Debug/Mule.dll"
		}
