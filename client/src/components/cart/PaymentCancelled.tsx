import React, { useEffect } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { FaTimesCircle } from 'react-icons/fa';
import { fetchFullOrder, UpdateFullOrder } from '../../scripts/fullOrderFunctions';

const PaymentCancelled: React.FC = () => {
  const navigate = useNavigate();
  const { id } = useParams<{ id: string }>();

  useEffect(() => {
    const cancelOrder = async () => {
      try {
        const fullOrder = await fetchFullOrder(id!);
        await UpdateFullOrder({ ...fullOrder, status: 3 });

        // Wait for the update operation to finish and at least 4 seconds
        await Promise.all([
          new Promise(resolve => setTimeout(resolve, 4000)),
          UpdateFullOrder({ ...fullOrder, status: 3 })
        ]);

        navigate('/FullOrders');
      } catch (error) {
        console.error('Error updating order status:', error);
      }
    };

    cancelOrder();
  }, [id, navigate]);

  return (
    <div style={{ textAlign: 'center', marginTop: '50px' }}>
      <FaTimesCircle size={50} color="red" />
      <h2>Payment was cancelled!</h2>
      <p>You will be redirected back shortly...</p>
    </div>
  );
};

export default PaymentCancelled;