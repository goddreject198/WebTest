$(document).ready(function () {
    ShowCount();
    $('body').on('click', '.btnAddToCart', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var quantity = 1;
        var tQuantity = $('#quantity_value').text();
        if (tQuantity != '') {
            quantity = parseInt(tQuantity);
        }
        
        $.ajax({
            url: '/shoppingcart/addtocart',
            type: 'POST',
            data: { id: id, quantity: quantity},
            success: function (rs) {
                if (rs.Success) {
                    $('#checkout_items').html(rs.count);
                    alert(rs.msg);
                }
            }
        });
    });

    $('body').on('click', '.btnUpdate', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var quantity = $('#Quantity_' + id).val();
        Update(id, quantity);
    });

    $('body').on('click', '.btnDelete', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var conf = confirm('Bạn có muốn xóa sản phẩm này khỏi giỏ hàng không?'); 
        if (conf == true) {
            $.ajax({
                url: '/shoppingcart/delete',
                type: 'POST',
                data: { id: id },
                success: function (rs) {
                    if (rs.Success) {
                        $('#checkout_items').html(rs.count);
                        $('#trow_' + id).remove();
                        LoadCart();
                    }
                }
            });
        }
    });

    $('body').on('click', '.btnDeleteAll', function (e) {
        e.preventDefault();
        var conf = confirm('Bạn có muốn xóa hết sản phẩm trong giỏ hàng không?');
        if (conf == true) {
            DeleteAll();
        }
    });
});

function ShowCount() {
    $.ajax({
        url: '/shoppingcart/showcount',
        type: 'GET',
        success: function (rs) {
            $('#checkout_items').html(rs.Count);
        }
    });
}

function DeleteAll() {
    $.ajax({
        url: '/shoppingcart/deleteall',
        type: 'POST',
        success: function (rs) {
            if (rs.Success) {
                LoadCart();
            }
        }
    });
}

function Update(id, quantity) {
    $.ajax({
        url: '/shoppingcart/update',
        type: 'POST',
        data: {id:id, quantity:quantity},
        success: function (rs) {
            if (rs.Success) {
                LoadCart();
            }
        }
    });
}

function LoadCart() {
    $.ajax({
        url: '/shoppingcart/partial_item_cart',
        type: 'GET',
        success: function (rs) {
            $('#load_data').html(rs);
        }
    });
}