import React, { useEffect, useState } from 'react';
import { View, Text, FlatList, Button, StyleSheet } from 'react-native';
import { getProducts, addProduct } from '../services/productService';
import Toast from 'react-native-toast-message';

const ProductList = ({ navigation }) => {
    const [products, setProducts] = useState([]);

    useEffect(() => {
        fetchProducts();
    }, []);

    const fetchProducts = async () => {
        try {
            const response = await getProducts();
            console.log(response);
            setProducts(response);
        } catch (error) {
            console.error('Error fetching products:', error);
        }
    };

    const handleAddToCart = async (item) => {
        try {
            const response = await addProduct(item);
            console.log(response);
            if (response.success) {
                console.log('Si');
                Toast.show({
                    type: 'success',
                    text1: 'Éxito',
                    text2: 'Producto agregado al carrito correctamente',
                });
            } else {
                Toast.show({
                    type: 'error',
                    text1: 'Error',
                    text2: response.message,
                });
            }
        } catch (error) {
            console.error('Error adding to cart:', error);
            Toast.show({
                type: 'error',
                text1: 'Error',
                text2: 'Hubo un problema al agregar el producto al carrito',
            });
        }
    };

    const renderHeader = () => (
        <View style={styles.headerContainer}>
            <Text style={styles.headerText}>Nombre</Text>
            <Text style={styles.headerText}>Precio</Text>
            <Text style={styles.headerText}>Stock</Text>
            <Text style={styles.headerText}>Fecha de Ingreso</Text>
            <Text style={styles.headerText}>Validacion</Text>
            <Text style={styles.headerText}>Acciones</Text>
        </View>
    );

    const renderItem = ({ item }) => (
        <View style={styles.productItem}>
            <Text style={styles.itemText}>{item.nombre}</Text>
            <Text style={styles.itemText}>{item.precio}</Text>
            <Text style={styles.itemText}>{item.stock}</Text>
            <Text style={styles.itemText}>{item.fechaIngreso}</Text>
            <Text style={styles.itemText}>{item.validacion.toString()}</Text>
            <View style={styles.actionsContainer}>
                <Button title="Ver Detalle" onPress={() => navigation.navigate('ProductDetail', { product: item })} />
                <Button title="Agregar Carrito" onPress={() => handleAddToCart(item)} />
            </View>
        </View>
    );

    return (
        <View style={styles.container}>
            <Text style={styles.title}>Lista de Productos</Text>
            <FlatList
                data={products}
                keyExtractor={(item) => item.productoID.toString()}
                ListHeaderComponent={renderHeader}
                renderItem={renderItem}
            />
        </View>
    );
};

const styles = StyleSheet.create({
    container: {
        flex: 1,
        paddingTop: 22,
        paddingHorizontal: 10,
        backgroundColor: '#fff',
    },
    title: {
        fontSize: 24,
        fontWeight: 'bold',
        marginBottom: 20,
        textAlign: 'center',
    },
    headerContainer: {
        flexDirection: 'row',
        justifyContent: 'space-between',
        backgroundColor: '#f1f1f1',
        padding: 10,
        borderBottomWidth: 1,
        borderBottomColor: '#ccc',
    },
    headerText: {
        flex: 1,
        fontWeight: 'bold',
        textAlign: 'center',
    },
    productItem: {
        flexDirection: 'row',
        justifyContent: 'space-between',
        alignItems: 'center',
        backgroundColor: '#f9f9f9',
        padding: 10,
        marginBottom: 10,
        borderRadius: 5,
        borderBottomWidth: 1,
        borderBottomColor: '#ccc',
    },
    itemText: {
        flex: 1,
        textAlign: 'center',
    },
    actionsContainer: {
        flexDirection: 'row',
        justifyContent: 'space-around',
        flex: 2,
    },
});

export default ProductList;
