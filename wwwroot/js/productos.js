$(document).ready(function () {
    $.ajax({
        url: '/Productos/ObtenerProductos',
        method: 'GET',
        success: function (data) {
            var tableBody = $('#tabla-productos tbody');
            tableBody.empty(); // Limpiar la tabla antes de agregar nuevos datos
            data.forEach(function (producto) {
                var row = `<tr>
                    <td>${producto.idProducto}</td>
                    <td>${producto.tipoProducto}</td>
                    <td>${producto.marcaProducto}</td>
                    <td>${producto.modeloProducto}</td>
                    <td>${producto.precioVenta}</td>
                    <td>
                        <a href="/Productos/Edit/${producto.idProducto}" class="btn btn-warning">Editar</a>
                        <a href="/Productos/Delete/${producto.idProducto}" class="btn btn-danger">Eliminar</a>
                    </td>
                </tr>`;
                tableBody.append(row);
            });
        },
        error: function () {
            alert('Error al cargar los productos');
        }
    });
});
