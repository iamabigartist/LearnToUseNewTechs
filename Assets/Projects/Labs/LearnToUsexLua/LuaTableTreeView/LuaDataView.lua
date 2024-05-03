function GetViewData(root_variable, ref_dict)

    ref_dict = ref_dict or {}

    local root_type = type(root_variable)
    local root_value = tostring(root_variable)
    local root_item = {
        key = "root",
        type = root_type,
        value = root_value,
        children = {}
    }
    
    if root_type == "table" then
        if ref_dict[root_variable] then
            root_item.value = root_item.value .. " (ref)"
        else
            ref_dict[root_variable] = true
            local key_sort_list = {}
            local key_dict = {}
            for k, _ in pairs(root_variable) do 
                local key_str = tostring(k)
                key_dict[key_str] = k
                table.insert(key_sort_list, key_str) 
            end
            table.sort(key_sort_list)
            for _, key_str in ipairs(key_sort_list) do
                local cur_item = GetViewData(root_variable[key_dict[key_str]], ref_dict)
                cur_item.key = key_str
                root_item.children[key_str] = cur_item
            end
        end
    end
    
    return root_item    
end
