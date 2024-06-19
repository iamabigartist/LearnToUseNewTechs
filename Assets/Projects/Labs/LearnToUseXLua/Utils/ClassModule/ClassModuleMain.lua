local 

local ClassModuleFuncList = {}

local function CLassMode_index(t, k)
    local f = ClassModuleFuncList[k]
    if f then return f end
    return { is_declaration = true, name = k }
end

local function CLassMode_newindex(t, k, v)
    rawset(t, k, v)
end

ClassMode_ENV_MT = {
    __index = function(t, k)
        return CLassMode_index(t, k)
    end,
    __newindex = function(t, k, v)
        CLassMode_newindex(t, k, v)
    end
}
