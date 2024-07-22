import React, { useState, useEffect } from 'react';
import { View, TextInput, Button, StyleSheet } from 'react-native';

const ProductForm = ({ product, onAddProduct, onSubmit, onCancel, submitButtonText }) => {
    const [productName, setProductName] = useState('');

    useEffect(() => {
        if (product) {
            setProductName(product.producto); // Corregido: Utiliza product.producto para establecer el nombre del producto
        }
    }, [product]);

    const handleAddProductClick = () => {
        onAddProduct(productName);
        setProductName('');
    };

    const handleUpdateProductClick = () => {
        const updatedProduct = { ...product, producto: productName }; // Corregido: Actualiza product.producto con el nuevo nombre
        onSubmit(updatedProduct);
        setProductName('');
    };

    const handleCancelClick = () => {
        onCancel();
        setProductName('');
    };

    return (
        <View style={styles.container}>
            <TextInput
                style={styles.input}
                placeholder="Nombre del Producto"
                value={productName}
                onChangeText={(text) => setProductName(text)}
            />
            {product ? (
                <View style={styles.buttonContainer}>
                    <Button title={submitButtonText} onPress={handleUpdateProductClick} />
                    <Button title="Cancelar" onPress={handleCancelClick} color="gray" />
                </View>
            ) : (
                <Button title="Guardar" onPress={handleAddProductClick} />
            )}
        </View>
    );
};

const styles = StyleSheet.create({
    container: {
        width: '100%',

        paddingHorizontal: 20,
        marginBottom: 20,
    },
    input: {
        height: 40,
        borderColor: 'gray',
        borderWidth: 1,
        marginBottom: 10,
        paddingHorizontal: 10,
    },
    buttonContainer: {
        flexDirection: 'row',
        justifyContent: 'space-between',
        alignItems: 'center',
        marginTop: 10,
    },
});

export default ProductForm;
