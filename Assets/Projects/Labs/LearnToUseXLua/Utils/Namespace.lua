﻿-- Example
--[[

Namespace().Project.Labs.NamespaceModuleExample()
Using().Project.Utils.Math.Random()
Using().Project.cjson()

cjson.encode({a=1, b=2, c=3})
print(random(1, 100))

--]]

-- Namespace declaration expression metatable, can create new namespace and call to claim current file
local namespace_mt = {
    __index = function(cur_ns, key)
        if type(key) == "string" then
            if not cur_ns[key] then rawset(cur_ns, key, BuildNamespaceTable(cur_ns, key)) end
            return rawget(cur_ns, key)
        else
            error("Invalid key type for namespace table, only string is allowed.")
        end
    end,

    __newindex = function(cur_ns, key, value)
        error("Cannot assign value to namespace table.")
    end,

    __call = function(cur_ns, ...)
        if ... then error("Namespace table cannot be called with parameters.") end
        ClaimNamespaceFile(cur_ns)
    end
}

-- Using expression, can create new namespace and call to return a ref of the ns, be set into the fenv of current file
local using_mt = {
    
}

-- Used outside namespace mode, to require a module and return the module table
local require_mt = {}

function InitNamespaceModule()
    NamespaceModule = {
        NamespaceRoot = {},
        UsingRoot = {},
        RequireRoot = {},
        NS_Dict = {},
    }
    setmetatable(NamespaceModule.NamespaceRoot, namespace_mt)
end

function BuildNamespaceTable(parent_ns, ns_name)
    local ns_tbl = { __parent_ns = parent_ns }
    setmetatable(ns_tbl, ns_tbl_mt)
    NS_Dict:Collect(ns_tbl, ns_name)
    return ns_tbl
end

function NS_Dict:Collect(ns_tbl, ns_name)
    if not self[ns_name] then self[ns_name] = {} end
    table.insert(self[ns_name], ns_tbl)
end

nas_file_fenv_tbl_mt = {}

function ClaimNamespaceFile(cur_ns)
    
end



-- Enable the namespace mode for this file, in which:
-- 1. All the functions declared in this file will be stored in the table of the namespace
-- 2. The fenv of this file will be set, so only variables in this namespace and in the used namespace above can be accessed.
function Namespace()
    
    return GlobalNamespace
end

-- Search and return a namespace table which can be inited later and reference all the func declared in this namespace.
function Using()
end

InitNamespaceModule()
