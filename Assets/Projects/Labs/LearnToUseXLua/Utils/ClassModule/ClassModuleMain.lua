local function NewInstance(class_tbl, ...)
    local instance = {}
    setmetatable(instance, { __index = class_tbl })
    if instance.Ctor then instance:Ctor(...) end
    return instance
end

local class_mt = {}
function class_mt.__call(t, ...)
    return NewInstance(t, ...)
end

local function SetClassMt(tbl)
    setmetatable(tbl, class_mt)
end

return {
    SetClassTbl = SetClassTbl
}
