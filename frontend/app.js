const API_URL = "http://localhost:5279/api/requests";

let currentPage = 1;
const pageSize = 5;

async function loadRequests() {
    const search = document.getElementById("searchInput")?.value || "";
    const status = document.getElementById("statusFilter")?.value || "";

    const url =
        `${API_URL}?search=${encodeURIComponent(search)}&status=${encodeURIComponent(status)}&page=${currentPage}&pageSize=${pageSize}`;

    const response = await fetch(url);
    const data = await response.json();

    const tableBody = document.getElementById("requestTableBody");
    tableBody.innerHTML = "";

    data.forEach(request => {
        tableBody.innerHTML += `
            <tr>
                <td>${request.id}</td>
                <td>${request.customerName}</td>
                <td>${request.deviceName}</td>
                <td>${request.status}</td>
                <td>${new Date(request.createdDate).toLocaleString()}</td>
            </tr>
        `;
    });

    document.getElementById("pageInfo").innerText = `Sayfa ${currentPage}`;
}

async function createRequest() {
    const customerName = document.getElementById("customerName").value;
    const deviceName = document.getElementById("deviceName").value;
    const description = document.getElementById("description").value;

    const response = await fetch(API_URL, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            customerName,
            deviceName,
            description
        })
    });

    if (response.ok) {
        document.getElementById("customerName").value = "";
        document.getElementById("deviceName").value = "";
        document.getElementById("description").value = "";

        currentPage = 1;
        loadRequests();
    } else {
        alert("Kayıt oluşturulamadı. Alanları kontrol et.");
    }
}

function applyFilters() {
    currentPage = 1;
    loadRequests();
}

function nextPage() {
    currentPage++;
    loadRequests();
}

function previousPage() {
    if (currentPage > 1) {
        currentPage--;
        loadRequests();
    }
}

loadRequests();