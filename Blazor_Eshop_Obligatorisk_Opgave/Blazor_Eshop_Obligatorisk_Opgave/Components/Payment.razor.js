function initialisePayPal() {
    if (paypal.Buttons.instances.length >= 1) return;
    let container = document.getElementById('paypal_container');
    let total = document.getElementById('paypal_container').getAttribute('data-total');
    paypal.Buttons({
        style: {
            shape: 'rect',
            color: 'gold',
            layout: 'vertical',
            label: 'pay'
        },
        createOrder: function (data, actions) {
            console.log(data)
            return actions.order.create({
                purchase_units: [{
                    amount: {
                        value: total // Erstat med det ønskede beløb
                    }
                }]
            });
        },
        onApprove: async function (data, actions) {
            let orderId = data.orderID
            console.log(data)
            console.log("Order id: " + orderId)
            console.log("Newest line again")
            let apiCall = 'https://api-m.sandbox.paypal.com/v2/checkout/orders/' + orderId + '/'
            let accessToken;
    await (async () => {
        try {
            accessToken = await getAccessToken();
            console.log("This is the accessToken response: " + accessToken);
            console.log("Access token is set: " + accessToken);
        } catch (error) {
            console.error('Error:', error);
        }
    })();
            console.log("This is the accesstokenresponse: "+accessToken)
            let auth = 'Bearer ' + accessToken
            console.log(auth)
            const orderResponse = fetch(apiCall + 'confirm-payment-source', {
                method: 'POST',
                headers: {
                    'Authorization': auth,
                    'Content-Type': 'application/json; charset=UTF-8',
                    'Prefer': 'return=representation'
                },
                body: JSON.stringify({
                    "payment_source": {
                        "paypal": {
                            "name": { "given_name": "John", "surname": "Doe" },
                            "email_address": "customer@example.com",
                            "experience_context":
                            {
                                "payment_method_preference": "IMMEDIATE_PAYMENT_REQUIRED",
                                "brand_name": "EXAMPLE INC",
                                "locale": "en-US",
                                "landing_page": "LOGIN",
                                "shipping_preference": "SET_PROVIDED_ADDRESS",
                                "user_action": "PAY_NOW",
                                "return_url": "https://example.com/returnUrl",
                                "cancel_url": "https://example.com/cancelUrl"
                            }
                        }
                    },
                })
            }).then(authorizeResponse => {
                // Handle authorization response
                // Assuming you want to proceed with capturing immediately after authorization
                return fetch(apiCall + 'capture', {
                    method: 'POST',
                    headers: {
                        'Authorization': auth,
                        'Content-Type': 'application/json; charset=UTF-8',
                        'PayPal-Request-Id': '7b92603e-77ed-4896-8e78-5dea2050476a' // Replace with your request id
                    }
                });
            }).then(captureResponse => {
                // Handle capture response
                console.log(' response:', captureResponse);
                return captureResponse.json();
            }).then(response => {
                if (response.status === 'COMPLETED') {
                    window.location.href = 'https://localhost:7077/success'


                }
                else {
                    window.location.href = 'https://localhost:7077/error'
                }
                console.log(response.status)
            }).catch(error => {
                // Handle errors
                failureCallback();
                console.error(error);
            });
            alert('Betaling gennemført!'); // Valgfri besked til brugeren
        }
    }).render(container);
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
    initialisePayPal();
}
export function onLoad() {
    initialisePayPal();
}
export function onDispose() {
    console.log('Dispose');
}