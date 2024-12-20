import React, { useState } from 'react';
import { loadStripe } from '@stripe/stripe-js';

const stripePromise = loadStripe('pk_test_51QXkdiLNotqjmzonh6Eq93L5S2bUfSPq65hRjvgl8jk8Apna9rzX97Pu2UlzcTrnUt352FNzRs12lZt3e5pZAg3d000iElLPhP');

const Cart: React.FC = () => {
  const [paymentStatus, setPaymentStatus] = useState<string | null>(null);

  const handlePayment = async () => {
    const stripe = await stripePromise;
    const { error } = await stripe!.redirectToCheckout({
      lineItems: [{ price: 'price_1QXkjDLNotqjmzon8skRAjsW', quantity: 1 }],
      mode: 'payment',
      successUrl: window.location.origin + '/payment-success',
      cancelUrl: window.location.origin + '/payment-cancel',
    });

    if (error) {
      console.error('Error redirecting to checkout:', error);
    }
  };

  return (
    <div>
      <button onClick={handlePayment}>Pay Now</button>
      {paymentStatus && <div>{paymentStatus}</div>}
    </div>
  );
};

export default Cart;