import React, { useEffect } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { FaCheckCircle } from 'react-icons/fa';
import { fetchFullOrder, UpdateFullOrder } from '../../scripts/fullOrderFunctions';

const PaymentSuccess: React.FC = () => {
  const navigate = useNavigate();
  const { id } = useParams<{ id: string }>();

  useEffect(() => {
    const updateOrderStatus = async () => {
      try {
        const fullOrder = await fetchFullOrder(id!);
        await UpdateFullOrder({ ...fullOrder, status: 2 }); // Assuming 2 represents 'successful payment'

        // Wait for the update operation to finish and at least 4 seconds
        await new Promise(resolve => setTimeout(resolve, 4000));

        navigate('/FullOrders');
      } catch (error) {
        console.error('Error updating order status:', error);
      }
    };

    updateOrderStatus();
  }, [id, navigate]);

  return (
    <div style={{ textAlign: 'center', marginTop: '50px' }}>
      <FaCheckCircle size={50} color="green" />
      <h2>Payment was successful!</h2>
      <p>You will be redirected back shortly...</p>
    </div>
  );
};

export default PaymentSuccess;