// تخزين المخططات عالمياً للتمكن من تدميرها بأمان عند إعادة الرسم
window.myCharts = window.myCharts || {};

window.renderCharts = function (quartileData, pubNames, pubCounts) {
// --- 1. رسم توزيع الأرباع (Doughnut Chart) ---
var ctx1 = document.getElementById('quartileChart');
if (ctx1) {
// تدمير المخطط القديم إذا كان موجوداً لمنع تداخل الرسوم
if (window.myCharts['quartileChart']) {
window.myCharts['quartileChart'].destroy();
}

window.myCharts['quartileChart'] = new Chart(ctx1, {
type: 'doughnut',
data: {
labels: ['Q1', 'Q2', 'Q3', 'Q4'],
datasets: [{
data: quartileData,
backgroundColor: ['#16A34A', '#3B82F6', '#F59E0B', '#EF4444'],
borderWidth: 0,
hoverOffset: 4
}]
},
options: {
responsive: true,
maintainAspectRatio: false,
plugins: {
legend: {
position: 'bottom',
labels: { font: { family: 'Segoe UI, Cairo, sans-serif', size: 13, weight: 'bold' } }
}
},
cutout: '70%'
}
});
}

// --- 2. رسم الناشرين (Bar Chart) ---
var ctx2 = document.getElementById('publishersChart');
if (ctx2) {
// تدمير المخطط القديم إذا كان موجوداً
if (window.myCharts['publishersChart']) {
window.myCharts['publishersChart'].destroy();
}

window.myCharts['publishersChart'] = new Chart(ctx2, {
type: 'bar',
data: {
labels: pubNames,
datasets: [{
label: 'عدد المجلات',
data: pubCounts,
backgroundColor: '#6366F1',
borderRadius: 6,
barThickness: 25
}]
},
options: {
responsive: true,
maintainAspectRatio: false,
plugins: { legend: { display: false } },
scales: {
y: { beginAtZero: true, ticks: { stepSize: 1 }, grid: { display: false } },
x: { grid: { display: false }, ticks: { font: { family: 'Segoe UI, Cairo, sans-serif', size: 11 } } }
}
}
});
}
};

window.renderPieChart = (canvasId, q1, q2, q3, q4) => {
const ctx = document.getElementById(canvasId);
if (!ctx) return;

if (window.myCharts[canvasId]) {
window.myCharts[canvasId].destroy();
}

window.myCharts[canvasId] = new Chart(ctx, {
type: 'doughnut',
data: {
labels: ['Q1', 'Q2', 'Q3', 'Q4'],
datasets: [{
data: [q1, q2, q3, q4],
backgroundColor: ['#198754', '#0dcaf0', '#ffc107', '#6c757d'],
borderWidth: 0
}]
},
options: {
responsive: true,
plugins: {
legend: { position: 'bottom', labels: { font: { family: 'Cairo, sans-serif' } } }
}
}
});
};

window.renderBarChart = (canvasId, labels, data) => {
const ctx = document.getElementById(canvasId);
if (!ctx) return;

if (window.myCharts[canvasId]) {
window.myCharts[canvasId].destroy();
}

window.myCharts[canvasId] = new Chart(ctx, {
type: 'bar',
data: {
labels: labels,
datasets: [{
label: 'معامل التأثير',
data: data,
backgroundColor: '#0d6efd',
borderRadius: 8
}]
},
options: {
responsive: true,
plugins: {
legend: { display: false }
},
scales: {
y: { beginAtZero: true }
}
}
});
};