async function getOrders() {
    try {
        // Get the current date
        const currentDate = new Date();
        let container = document.getElementById('orders');
        // Subtract 30 days from the current date
        const startDate = new Date(currentDate);
        startDate.setDate(startDate.getDate() - 30);

        // Format the start date as required (e.g., 'YYYY-MM-DDTHH:mm:ssZ')
        const formattedStartDate = startDate.toISOString();
        let accessToken; 
        const query = new URLSearchParams({
            start_date: formattedStartDate,
            end_date: currentDate.toISOString(),
            page_size: '500',
            fields: [
                'transaction_info',
                'payer_info',
                'shipping_info',
                ],
        }).toString();
        await (async () => {
            try {
                accessToken = await getAccessToken();
                console.log("This is the accessToken response: " + accessToken);
                console.log("Access token is set: " + accessToken);
            } catch (error) {
                console.error('Error:', error);
            }
        })();
        let auth = 'Bearer ' + accessToken
        console.log(auth)
        const response = await fetch('https://api-m.sandbox.paypal.com/v1/reporting/transactions?' + query, {
            headers: {
                'Authorization': auth,
                'Content-Type': 'application/json; charset=UTF-8',
            }
        }).then(response => {
            // Handle response here
            return response.json();
        });
        console.log(response)
        const orders = response.transaction_details;


        let html = '<div class="container"><table class="table table-bordered text-center"><thead class="thead-dark"><tr><th>Index</th><th>Name</th><th>Last Name</th><th>Amount</th><th>Time</th><th>Address</th><th>City</th><th>Country Code</th><th>Postal Code</th></tr></thead><tbody>';

        // Reverse the orders list
        orders.reverse();

        // Start iterating from the 3rd order
        for (let i = 2; i < Math.min(orders.length, 60); i += 3) {
            const order = orders[i];
            const transactionAmount = parseFloat(order.transaction_info.transaction_amount.value);
            const feeAmount = parseFloat(order.transaction_info.fee_amount.value);
            const valueAmount = transactionAmount + feeAmount;
            const amount = valueAmount;
            const roundedAmount = parseFloat(amount).toFixed(2) + ' ' + order.transaction_info.transaction_amount.currency_code;
            const time = new Date(order.transaction_info.transaction_initiation_date).toLocaleString();
            const address = order.shipping_info?.address?.line1 || 'N/A';
            const city = order.shipping_info?.address?.city || 'N/A';
            const countryCode = order.shipping_info?.address?.country_code || 'N/A';
            const postalCode = order.shipping_info?.address?.postal_code || 'N/A';
            const name = order.payer_info?.payer_name?.given_name || 'N/A';
            const lastName = order.payer_info?.payer_name?.surname || 'N/A';

            const index = Math.ceil(i / 3); // Adjust index accordingly

            html += `<tr><td>${index}</td><td>${name}</td><td>${lastName}</td><td>${roundedAmount}</td><td>${time}</td><td>${address}</td><td>${city}</td><td>${countryCode}</td><td>${postalCode}</td></tr>`;
        }

        html += '</tbody></table></div>';





        container.innerHTML = html;
        return orders;
    } catch (error) {
        console.error('Error fetching orders:', error.message);
        throw error;
    }
}

function getAccessToken() {
    const clientId = "AZ3m7VwNke2SF8S47joCMQmVXgOXnkaveyHwj_O13Bbke7g8WqEhHm8PHgqy0TR0dhrBhRtMPUvrMWXq";
    const clientSecret = "EDrZMrjto5B3PCICgy1PyvPdp4oDAhD8zVc5tMAp3ULZclBSVfd1Q0WD5xq8sdkWn-Hqs1xUyPNTnUBI";

    const url = "https://api-m.sandbox.paypal.com/v1/oauth2/token";
    const body = "grant_type=client_credentials";

    return fetch(url, {
        method: 'POST',
        headers: {
            'Authorization': 'Basic ' + btoa(clientId + ':' + clientSecret),
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        body: body
    })
        .then(response => response.json())
        .then(responseJSON => {
            return responseJSON.access_token;
        })
        .catch(error => console.error('Error:', error));
}

export function onUpdate() {
    getOrders();
}
export function onLoad() {
    getOrders();
}