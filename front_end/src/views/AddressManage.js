import React, { useRef, useEffect, useState } from "react";
import { Image, Text, View, StyleSheet, TouchableOpacity, Dimensions, KeyboardAvoidingView } from "react-native";
import Constants from "expo-constants";
import * as firebase from "firebase";
import { FlatList, ScrollView, TextInput } from "react-native-gesture-handler";
import StickyParallaxHeader from "react-native-sticky-parallax-header";
import { Modalize } from "react-native-modalize";
import Backbutton from "../component/BackButton";
import api from "../const/api";
import { setAddress, getAddress } from "../redux/index";
import { connect } from "react-redux";

const { width, height } = Dimensions.get("window");

const AddressManage = ({ navigation, ...props }) => {
  const { selectedAddress } = props;
  const [data, setData] = useState([]);
  const [isLoading, setLoading] = useState(true);

  const getAddress = async () => {
    try {
      const user = await firebase.auth().currentUser;
      let uid = user.uid;
      const response = await fetch(`${api}/api/Address/Addresses/${uid}`);
      const json = await response.json();
      setData(json.responseData);
    } catch (error) {
      console.error(error);
    } 
  }

  const deleteAddress = async (id) => {
    try {
      console.log(`Delete`, id)
      await fetch(`${api}/api/Address/Address/${id}`, {
          method: 'DELETE',
          headers: {
            'Content-type': 'application/json; charset=UTF-8' // Indicates the content 
          },
        })
        .then((response) => response.json())
        .then((responseJson) => { console.log("response: " + JSON.stringify(responseJson));
        if(responseJson.message == 'Success')
        { 
          console.log("here");
          getAddress()
        }
        else 
        {
          console.log(responseJson);
        }
        }).catch((error) => {
            console.error(error);
        })} catch (error) {
      console.error(error);
    } 
  }

  useEffect(() => {
    const unsubscribe = navigation.addListener('focus', () => {
      getAddress();
    });
    return unsubscribe;
  },[navigation]);


  return (
    <View style={[StyleSheet.absoluteFill, styles.home]}>
      <View style={{ paddingBottom: 50 }}>
        <ScrollView> 
          <View style={styles.navbar}>
            <Backbutton />
          </View>
          <Text style={styles.pageTitle}>Shipping Address</Text>
          {data.map((item, index) => (
            <TouchableOpacity style={styles.address} key={`address_${index}`} onPress={() => props.setAddress(item)}>
              <TouchableOpacity style={styles.addressCancel} onPress={() => deleteAddress(item.id)}>
                <Image source={require("../images/cancel.png")} />
              </TouchableOpacity>
              <View style={styles.addressDetail}>
                {selectedAddress.id == item.id ? (
                  <Image style={styles.addressCheck} source={require("../images/address-point.png")} />
                ) : (
                  <Image style={styles.addressCheck} source={require("../images/address-point-uncheck.png")} />
                )}
                <View>
                  <Text style={styles.addressName}>{item.name}</Text>
                  <Text style={styles.addressText}>{item.city}</Text>
                  <Text style={styles.addressText}>{item.address}</Text>
                  <Text style={styles.addressText}>Mobile: {item.phone} </Text>
                </View>
                <TouchableOpacity style={styles.addressEditBtn} onPress={() => navigation.navigate("AddressEdit",item)}>
                  <Text style={styles.addressEditBtnText}>EDIT</Text>
                </TouchableOpacity>
              </View>
            </TouchableOpacity>
          ))}
        </ScrollView>
      </View>
      <TouchableOpacity style={styles.addBtn} onPress={() => navigation.push("AddressEdit")}>
        <Text style={styles.addBtnText}>+ Add new address</Text>
      </TouchableOpacity>
    </View>
  );
};

const mapStateToProps = (state) => ({
  selectedAddress: state.general.selectedAddress,
  addresses: state.general.addresses,
});

const mapDispatchToProps = {
  setAddress,
};

export default connect(mapStateToProps, mapDispatchToProps)(AddressManage);

const styles = StyleSheet.create({
  home: {
    backgroundColor: "#F5F5F5",
  },
  navbar: {
    padding: 10,
    justifyContent: "space-between",
    flexDirection: "row",
    alignItems: "center",
  },
  navbarButton: {
    display: "flex",
    padding: 0,
    width: 30,
    height: 30,
    justifyContent: "center",
    alignItems: "center",
  },
  navbarButtonMargin: {
    marginHorizontal: 0,
  },
  navbarGroup: {
    flexDirection: "row",
    alignItems: "center",
  },
  pageTitle: {
    fontSize: 24,
    fontWeight: "bold",
    color: "#282C40",
    paddingHorizontal: 10,
  },
  nextBtn: {
    position: "absolute",
    zIndex: 100,
    bottom: 0,
    backgroundColor: "#5780D9",
    left: 0,
    width: "100%",
    justifyContent: "center",
    flexDirection: "row",
    padding: 15,
  },
  nextBtnText: {
    fontWeight: "bold",
    fontSize: 20,
    color: "#fff",
    textTransform: "uppercase",
  },
  addBtn: {
    position: "absolute",
    zIndex: 100,
    bottom: 0,
    backgroundColor: "#5780D9",
    left: 0,
    width: "100%",
    justifyContent: "center",
    flexDirection: "row",
    padding: 15,
  },
  addBtnText: {
    fontWeight: "bold",
    fontSize: 18,
    color: "#fff",
  },
  address: {
    backgroundColor: "#fff",
    margin: 20,
    padding: 20,
    marginTop: 20,
    borderRadius: 10,
  },
  addressText: {
    color: "#282C408C",
    fontSize: 16,
    lineHeight: 25,
    width: "80%",
  },
  addressName: {
    color: "#282C40",
    fontSize: 18,
    width: "70%",
    fontWeight: "bold",
  },
  addressDetail: {
    flexDirection: "row",
  },
  addressEditBtn: {
    marginLeft: "auto",
    alignSelf: "center",
    borderWidth: 1,
    borderRadius: 20,
    paddingHorizontal: 12,
    paddingVertical: 4,
    borderColor: "#D0D0D0",
  },
  addressEditBtnText: {
    color: "#5780D9",
    fontWeight: "bold",
    fontSize: 14,
  },
  addressCheck: {
    marginRight: 10,
    marginTop: 5,
  },
  addressCancel: {
    position: "absolute",
    top: 20,
    right: 20,
  },
});
