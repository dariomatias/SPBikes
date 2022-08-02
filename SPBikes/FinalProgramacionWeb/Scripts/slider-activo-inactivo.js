function cambiarEstado() {
    var slider = document.getElementById('slider');
    var activo = slider.classList.contains('activo');

    if (activo) {
        slider.classList.remove('activo');
        slider.classList.add('inactivo');
    } else {
        slider.classList.remove('inactivo');
        slider.classList.add('activo');
    }
}