const form = document.getElementById('employeeForm');

// Добавление сотрудника
form.addEventListener('submit', async function (e) {
    e.preventDefault();

    const formData = {
        name: document.getElementById('name').value,
        position: document.getElementById('position').value,
        department: document.getElementById('departmentsDynamic').value,
        place: document.getElementById('place').value,
        infoSystem: document.getElementById('infoSystemsDynamic').value,
        login: document.getElementById('login').value,
        phoneOut: document.getElementById('phoneOut').value,
        phoneIn: document.getElementById('phoneIn').value
    };
    try {
        const response = await fetch('/api/employee', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(formData)
        });

        if (response.ok) {
            form.reset();
            loadEmployees();
        }
    } catch (error) {
        console.error('Ошибка при добавлении сотрудника:', error);
    }
});

document.addEventListener('DOMContentLoaded', function () {
    debugger
    fetch('/api/department')
        .then(response => response.json())
        .then(data => {
            const select = document.getElementById('departmentsDynamic');
             debugger
            data.forEach(dept => {
                const option = document.createElement('option');
                option.value = dept.id;
                option.textContent = dept.name;
                select.appendChild(option);
            });
            if (window.jQuery && $(select).hasClass('selectpicker')) {
                $(select).selectpicker('refresh');
            }
        })
        .catch(error => {
            console.error('Ошибка загрузки подразделений:', error);
        });
});

document.addEventListener('DOMContentLoaded', function () {
    debugger
    fetch('/api/infoSystem')
        .then(response => response.json())
        .then(data => {
            const select = document.getElementById('infoSystemsDynamic');
            debugger
            data.forEach(dept => {
                const option = document.createElement('option');
                option.value = dept.id;
                option.textContent = dept.name;
                select.appendChild(option);
            });
            if (window.jQuery && $(select).hasClass('selectpicker')) {
                $(select).selectpicker('refresh');
            }
        })
        .catch(error => {
            console.error('Ошибка загрузки подразделений:', error);
        });
});

// Загружаем список сотрудников при загрузке страницы
//loadEmployees();