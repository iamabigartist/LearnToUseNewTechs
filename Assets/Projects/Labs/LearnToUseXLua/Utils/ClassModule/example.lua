Class(Cat,
    function()
        static_field
        (
            sleep_time,
            MaxHP,
            MaxMP,
            Strength,
            Agile
        )

        field
        (
            name,
            meow_sound,
            fur_color
        )

        method(Cat,
            function(Cat, name, meow_sound, fur_color)
                Cat.name = name
                Cat.meow_sound = meow_sound
                Cat.fur_color = fur_color
            end
        )
    end
)
