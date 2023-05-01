using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thang_Paint.Action
{
    internal interface IUpdate
    {

        /// <summary>
        /// Phương thức xử lý khi người dụng chọn chế độ select
        /// </summary>
        void onClickSelectMode();

        /// <summary>
        /// Phương thức xử lý khi người dụng chọn thay đổi màu sắc
        /// </summary>
        /// <param name="color">Màu cần đổi</param>
        /// <param name="g">Áp dụng lên graphic g</param>
        void onClickSelectColor(Color color, Graphics g);

        /// <summary>
        /// Phương thức xử lý khi người dụng chọn thay đôi kích thước đường vẽ
        /// </summary>
        /// <param name="size"></param>
        void onClickSelectSize(int size, Graphics g);

        void onClickSelectDashStyle(DashStyle dashStyle, Graphics g);

        /// <summary>
        /// Phương thức xử lý khi người dụng chọn chế độ fill
        /// </summary>
        /// <param name="btn"></param>
        /// <param name="g"></param>
        void onClickSelectFill(Button btn, Graphics g);

        void onClickSelectPen(Graphics g);


        void onClickSelectZoom(float zoomFactor, Graphics g);
         void onClickDeleteShape();

    }
}
