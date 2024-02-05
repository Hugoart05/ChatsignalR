$(document).ready(function () {
    $("#buscaUsuarios").on('click', function (e) {
        e.preventDefault();
        ShowOrHidenElement(true)
    })
    $("#closebox").on("click", function (e) {
        e.preventDefault()
        ResetCampos()
        ShowOrHidenElement(false)
    })
    $("#searchinput").on('input', function (e) {
        BuscarContatos()
    })
    $("main").on('click', function (e) {
        debugger;
        e.preventDefault()
        if (e.target.classList.contains('parent-div')) {
            console.log(e.target.id)
            /*BuscarERenderizarMensagensUsuarioId(e.target.id)*/
        }
      
    })

    $(".card-contato").on("click", function (e) {
        console.log(this)
    })
    //Manupulação de dom
    function ShowOrHidenElement(bool) {
        if (bool) {
            $("#boxUsers").removeClass('hidden-box')
                .addClass('element-search-show ')
            $("#searchinput").removeClass('hidden-box')
                .addClass('element-search-show ')
            $("#buscaUsuarios").addClass('hidden-box')
            return
        } else {
            $("#boxUsers").addClass('hidden-box ')
                .removeClass('element-search-show')
            $("#searchinput").addClass('hidden-box ')
                .removeClass('element-search-show')
            $("#buscaUsuarios").removeClass('hidden-box')
            return
        }
    }
    function ResetCampos() {
        $("#userCards").delay(4000).html("")
        $("#searchinput").val("")
    }
    //ApiRequests
    function AdicionaDelay(func, delay) {
        let timeoutId;
        return function () {
            clearTimeout(timeoutId);
            timeoutId = setTimeout(func, delay);
        };
    }
    function BuscarContatos() {
        let input = { name: $("#searchinput").val() }
        console.log()
        if (input.name == "") {
            $("#userCards").html("")
            return
        }
        $.ajax({
            url: '/usuario/GetUsuariosByNickName',
            type: 'POST',
            data: JSON.stringify(input),
            contentType: 'application/json',
            processData: false,
            success: function (response) {
                if (Array.isArray(response)) {
                    $("#userCards").html("")
                    $.each(response, function (index, user) {
                        if (!user.isExist) {
                            $("#userCards").append(`
                                <div class="card-user ">
                                    <p class="text-dark">${user.name}</p>
                                    <button class="btn btn-primary">Add</button>
                                </div>
                        `)
                        }
                    })
                }
            },
            error: function (error) {
                console.error(error)
            }
        })
    }
    function BuscarERenderizarMensagensUsuarioId(contatoId) {
        let data = {contato: contatoId}
        $.ajax({
            url: "/contato/MensagensDoContatoId/1",
            method: 'GET',
            success: function (data) {
                console.log(data)
            },
            error: function () {
                console.log('erro')
            }
        })
    }
})